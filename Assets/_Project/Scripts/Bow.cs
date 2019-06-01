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
        _arrow != null && 
        !_arrow.IsFlying && 
        _arrowGrabber != null && 
        _arrow.FoundNotch;

    public float ArrowDistance01 => DistanceFromFirstGrab / MaxArrowDistance;
    public float DistanceFromFirstGrab => Vector3.Distance(_arrowGrabber.transform.position, _grabberFoundPos);

    private Arrow _arrow;
    private Vector3 _grabberFoundPos;
    private float _distanceFromStart;

    private Grabbable _bowGrabbable;
    private Grabber _arrowGrabber;

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

        if(_arrow == null)
            MakeNewArrow();
    }

    private Arrow MakeNewArrow()
    {
        _arrow = Instantiate(ArrowPrefab, _arrowGrabber.transform);
        var arrowGrab = _arrow.GetComponent<Grabbable>();
        _arrowGrabber.Grab(arrowGrab);

        // Subscribe to Grabber Inputs
        _arrowGrabber.GrabberInput.OnGrabUp += OnArrowGrabUp;

        return _arrow;
    }

    private void OnArrowGrabUp()
    {
        if (_arrow != null && _arrow.FoundNotch)
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

        _arrow.transform.position = Vector3.Lerp(startPosition, endPosition, ArrowDistance01);
        _arrow.transform.rotation = Notch.transform.rotation;

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
        if (_arrow != null && _arrow.FoundNotch)
            return;

        var hits = Physics.OverlapSphere(Notch.transform.position, Radius, ArrowLayer);
        foreach (var hit in hits)
        {
            var arrowHit = hit.GetComponentInParent<Arrow>();

            if (_arrow == null)
                _arrow = arrowHit;

            Vibrate(_arrowGrabber, 0.2F, 0.2F);

            if (_arrow != null && _arrow == arrowHit && _arrowGrabber != null && _arrowGrabber.IsGrabbing)
            {
                _arrow.Found(Notch);
                _grabberFoundPos = _arrowGrabber.transform.position;
            }
        }

        if (_arrow != null && !_arrow.FoundNotch && hits.Length == 0)
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

        _arrow.Fire(velocity);
        _arrow = null;

        MakeNewArrow();

        Vibrate(_arrowGrabber, 0, 0);

        _arrowGrabber.GrabberInput.OnGrabUp -= OnArrowGrabUp;
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