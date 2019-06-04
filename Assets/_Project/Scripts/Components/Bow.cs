using System;
using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Arrow ArrowPrefab;

    public LayerMask ArrowLayer;
    public BowNotch Notch;

    public float Radius = 0.2F;
    public float MaxArrowDistance = 0.8F;
    public float MaxArrowVelocity = 55;

    public float CoolDown = 0.1F;
    public bool CoolingDown { get; private set; }

    public bool CanLockArrow => 
        Arrow != null && 
        !Arrow.IsFlying && 
        _arrowGrabber != null && 
        Arrow.FoundNotch;

    public float ArrowDistance01 => DistanceFromFirstGrab / MaxArrowDistance;
    public float DistanceFromFirstGrab => Vector3.Distance(_arrowGrabber.transform.position, _grabberFoundPos);

    public Arrow Arrow { get; private set; }
    public event Action<Arrow> OnArrowCreated;

    private Vector3 _grabberFoundPos;
    private float _distanceFromStart;

    private Grabbable _bowGrabbable;
    private Grabber _arrowGrabber;

    public AudioSource FireSource;

    private void Awake()
    {
        _bowGrabbable = GetComponent<Grabbable>();
        _bowGrabbable.OnAttach += OnBowAttach;
    }

    private void OnBowAttach(IGrabber grabber)
    {
        var hands = FindObjectsOfType<Grabber>();
        foreach (var hand in hands)
        {
            if (hand.transform != grabber.transform)
                _arrowGrabber = hand;
        }

        if(Arrow == null)
            MakeNewArrow();
    }

    // Current only used as a test case
    public Arrow MakeArrow()
    {
        Arrow = Instantiate(ArrowPrefab);
        OnArrowCreated?.Invoke(Arrow);
        return Arrow;
    }

    private Arrow MakeNewArrow()
    {
        Arrow = Instantiate(ArrowPrefab, _arrowGrabber.transform);
        var arrowGrab = Arrow.GetComponent<Grabbable>();
        _arrowGrabber.Grab(arrowGrab);
        _arrowGrabber.GrabberInput.OnGrabUp += OnArrowGrabUp;
        OnArrowCreated?.Invoke(Arrow);

        return Arrow;
    }

    private void OnArrowGrabUp()
    {
        if (Arrow != null && Arrow.FoundNotch)
            OnArrowRelease();
    }

    public void Update()
    {
        FindArrow();
        LockArrow();
    }

    public void LockArrow()
    {
        if (!CanLockArrow)
        {
            return;
        }

        var startPosition = Notch.transform.position;
        var endPosition = Notch.transform.position - (Notch.transform.forward * MaxArrowDistance);

        Arrow.transform.position = Vector3.Lerp(startPosition, endPosition, ArrowDistance01);
        Arrow.transform.rotation = Notch.transform.rotation;

        var amount = Mathf.Lerp(0.2F, 0.8F,ArrowDistance01);
        Vibrate(_arrowGrabber, amount, amount);
    }

    public Vector3 ArrowPosition()
    {
        var startPosition = Notch.transform.position;
        var endPosition = Notch.transform.position - (Notch.transform.forward * MaxArrowDistance);

        return Vector3.Lerp(startPosition, endPosition, ArrowDistance01);
    }

    public void FindArrow()
    {
        if (Arrow != null && Arrow.FoundNotch)
            return;

        var hits = Physics.OverlapSphere(Notch.transform.position, Radius, ArrowLayer);
        foreach (var hit in hits)
        {
            var arrowHit = hit.GetComponentInParent<Arrow>();

            if (Arrow == null)
                Arrow = arrowHit;

            Vibrate(_arrowGrabber, 0.2F, 0.2F);

            if (Arrow != null && Arrow == arrowHit && _arrowGrabber != null && _arrowGrabber.IsGrabbing)
            {
                Arrow.Found(Notch);
                _grabberFoundPos = _arrowGrabber.transform.position;
            }
        }

        if (Arrow != null && !Arrow.FoundNotch && hits.Length == 0)
        {
            Vibrate(_arrowGrabber,0,0);
        }
    }

    public void Vibrate(Grabber grabber, float freq, float amp)
    {
        if (grabber == null)
            return;

        // TODO: Remove OVR Code
        var hand = grabber.Handedness == EHandedness.Left
            ? OVRInput.Controller.LTouch
            : OVRInput.Controller.RTouch;

        OVRInput.SetControllerVibration(freq, amp, hand);
    }

    private void OnArrowRelease()
    {
        if (CoolingDown)
            return;

        StartCoroutine(BeginCoolDown());

        var velocity = Mathf.Lerp(0, MaxArrowVelocity, ArrowDistance01);

        Arrow.Fire(velocity);
        Arrow = null;

        MakeNewArrow();

        Vibrate(_arrowGrabber, 0, 0);

        _arrowGrabber.GrabberInput.OnGrabUp -= OnArrowGrabUp;

        FireSource.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Notch.transform.position, Radius);
    }

    private IEnumerator BeginCoolDown()
    {
        CoolingDown = true;
        yield return new WaitForSeconds(CoolDown);
        CoolingDown = false;
    }
}