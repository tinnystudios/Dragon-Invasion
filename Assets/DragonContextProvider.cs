using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bind all Unique Context 
/// </summary>
public class DragonContextProvider : MonoBehaviour
{
    public Transform Player;
    public Transform Arrow;

    private List<IBind<Transform>> PlayerDependents = new List<IBind<Transform>>();
    private List<IBind<Transform>> ArrowDependents = new List<IBind<Transform>>();

    // TODO remove runtime GetComponents
    private void Awake()
    {
        var playerContexts = GetComponentsInChildren<PlayerContext>();
        var arrowContexts = GetComponentsInChildren<ArrowContext>();

        foreach (var arrowContext in arrowContexts)
        {
            var dependent = arrowContext.GetComponent<IBind<Transform>>();
            dependent.Bind(Arrow);

            ArrowDependents.Add(dependent);
        }

        foreach (var playerContext in playerContexts)
        {
            var dependent = playerContext.GetComponent<IBind<Transform>>();
            dependent.Bind(Player);

            PlayerDependents.Add(dependent);
        }
    }

    private void OnArrowChanged(Arrow arrow)
    {
        foreach (var dependent in ArrowDependents)
        {
            dependent.Bind(arrow.transform);
        }
    }
}