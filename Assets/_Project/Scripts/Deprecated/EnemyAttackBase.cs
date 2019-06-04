using UnityEngine;

public abstract class EnemyAttackBase : MonoBehaviour
{
    public abstract void Attack();
}

/// <summary>
/// A target for an enemy
/// </summary>
public interface ITarget
{

}
