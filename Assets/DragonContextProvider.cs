using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bind all Unique Context 
/// </summary>
public class DragonContextProvider : MonoBehaviour, IBind<BowHeroCharacter>
{
    public void Bind(BowHeroCharacter dependent)
    {
        var enemyContext = new EnemyContextArgs() { Player = dependent };
        Bind(enemyContext);
    }

    private List<IBind<Transform>> PlayerDependents = new List<IBind<Transform>>();
    private List<IBind<Transform>> ArrowDependents = new List<IBind<Transform>>();

    public void Bind(EnemyContextArgs enemyContextArgs)
    {
        var playerContexts = GetComponentsInChildren<PlayerContext>();
        var arrowContexts = GetComponentsInChildren<ArrowContext>();

        foreach (var playerContext in playerContexts)
        {
            var dependent = playerContext.GetComponent<IBind<Transform>>();
            dependent.Bind(enemyContextArgs.Player.transform);

            PlayerDependents.Add(dependent);
        }

        var player = enemyContextArgs.Player;

        player.OnBowPickedUp += bow =>
        {
            bow.OnArrowCreated += OnArrowCreated;
        };
    }

    private void OnArrowCreated(Arrow arrow)
    {
        // Bind a new arrow each time a new one is created
        foreach (var dependent in ArrowDependents)
        {
            dependent.Bind(arrow.transform);
        }
    }
}