using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Arrow ArrowPrefab;

    public LayerMask ArrowLayer;
    public BowNotch Notch;

    public float Radius = 0.2F;
    public float MaxArrowDistance = 1.5F;

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
        _arrowGrabber.GrabberInput.OnGrabDown += OnArrowGrabDown;
        _arrowGrabber.GrabberInput.OnGrabUp += OnArrowGrabUp;

        return _arrow;
    }

    private void OnArrowGrabDown()
    {
        _arrowGrabber.GrabberInput.OnGrabDown -= OnArrowGrabDown;
    }

    private void OnArrowGrabUp()
    {
        OnArrowRelease();
        _arrowGrabber.GrabberInput.OnGrabUp -= OnArrowGrabUp;
    }

    public void Update()
    {
        FindArrow();
        LockArrow();
    }

    public void LockArrow()
    {
        if (!CanLockArrow)
            return;

        var startPosition = Notch.transform.position;
        var endPosition = Notch.transform.position - (Notch.transform.forward * MaxArrowDistance);

        _arrow.transform.position = Vector3.Lerp(startPosition, endPosition, ArrowDistance01);
        _arrow.transform.rotation = Notch.transform.rotation;
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

            if (_arrow != null && _arrow == arrowHit && _arrowGrabber != null && _arrowGrabber.IsGrabbing)
            {
                _arrow.Found(Notch);
                _grabberFoundPos = _arrowGrabber.transform.position;
            }
        }
    }

    private void OnArrowRelease()
    {
        var velocity = Mathf.Lerp(0, 50, ArrowDistance01);

        _arrow.Fire(velocity);
        _arrow = null;

        MakeNewArrow();
    }
}