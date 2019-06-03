using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bind all Unique Context 
/// </summary>
public class DragonContextProvider : MonoBehaviour
{
    private List<IBind<Transform>> PlayerDependents = new List<IBind<Transform>>();
    private List<IBind<Transform>> ArrowDependents = new List<IBind<Transform>>();

    public void Bind(EnemyContextArgs enemyContextArgs)
    {
        var playerContexts = GetComponentsInChildren<PlayerContext>();
        var arrowContexts = GetComponentsInChildren<ArrowContext>();

        // List dependecies
        foreach (var arrowContext in arrowContexts)
        {
            var dependent = arrowContext.GetComponent<IBind<Transform>>();
            ArrowDependents.Add(dependent);
        }

        foreach (var playerContext in playerContexts)
        {
            var dependent = playerContext.GetComponent<IBind<Transform>>();
            dependent.Bind(enemyContextArgs.Player.transform);

            PlayerDependents.Add(dependent);
        }

        var player = enemyContextArgs.Player;

        Debug.Log("On Bind Enemy");

        if (player.Bow != null)
        {
            player.Bow.OnArrowCreated += OnArrowCreated;
        }
    }

    private void OnArrowCreated(Arrow arrow)
    {
        Debug.Log("Arrow created " + arrow);

        // Bind a new arrow each time a new one is created
        foreach (var dependent in ArrowDependents)
        {
            Debug.Log($"Bind {arrow.transform.name}");
            dependent.Bind(arrow.transform);
        }
    }
}