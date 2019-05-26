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
    Action OnGrab { get; set; }

    /// <summary>
    /// When a Grabbable is released
    /// </summary>
    Action OnRelease { get; set; }

    /// <summary>
    /// Unity Transform is automatically assigned
    /// </summary>
    Transform transform { get; }

    bool IsGrabbing { get; }
}