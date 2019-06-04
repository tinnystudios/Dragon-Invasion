using System;
using UnityEngine;

/// <summary>
/// An interface to Cross Platform Grabbers
/// </summary>
public interface IGrabber
{
    EHandedness Hand { get; }
    /// <summary>
    /// When a Grabbable is grabbed
    /// </summary>
    Action<IGrabbable> OnGrabAttach { get; set; }

    /// <summary>
    /// When an IGrabbable is successfully detatched
    /// </summary>
    Action<IGrabbable> OnGrabDetatch { get; set; }

    /// <summary>
    /// When a grab is released but not necessarily letting go of the object
    /// </summary>
    Action OnRelease { get; set; }

    /// <summary>
    /// Unity Transform is automatically assigned
    /// </summary>
    Transform transform { get; }

    bool IsGrabbing { get; }
}