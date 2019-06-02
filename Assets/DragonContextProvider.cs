using System.Collections.Generic;
using UnityEngine;

public class EnemyContextArgs
{
    public Transform Player;
    public Transform Arrow;
}

/// <summary>
/// Bind all Unique Context 
/// </summary>
public class DragonContextProvider : MonoBehaviour
{
    public Transform Player;
    public Transform Arrow;

    private List<IBind<Transform>> PlayerDependents = new List<IBind<Transform>>();
    private List<IBind<Transform>> ArrowDependents = new List<IBind<Transform>>();

    // Testing
    private void Awake()
    {
        Bind(new EnemyContextArgs() { Player = this.Player, Arrow = this.Arrow });
    }

    public void Bind(EnemyContextArgs enemyContextArgs)
    {
        var playerContexts = GetComponentsInChildren<PlayerContext>();
        var arrowContexts = GetComponentsInChildren<ArrowContext>();

        foreach (var arrowContext in arrowContexts)
        {
            var dependent = arrowContext.GetComponent<IBind<Transform>>();
            dependent.Bind(enemyContextArgs.Arrow);

            ArrowDependents.Add(dependent);
        }

        foreach (var playerContext in playerContexts)
        {
            var dependent = playerContext.GetComponent<IBind<Transform>>();
            dependent.Bind(enemyContextArgs.Player);

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