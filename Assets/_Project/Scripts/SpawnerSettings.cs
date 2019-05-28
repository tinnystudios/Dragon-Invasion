using UnityEngine;

[CreateAssetMenu]
public class SpawnerSettings : ScriptableObject
{
    /// <summary>
    /// The fastest it can spawn
    /// </summary>
    public float MinRate = 1.0F;

    /// <summary>
    /// The slowest it can spawn
    /// </summary>
    public float MaxRate = 2.5F;

    /// <summary>
    /// Get the current rate based on the difficulty settings
    /// </summary>
    /// <param name="curve"></param>
    /// <param name="progress"></param>
    /// <returns></returns>
    public float GetRate(AnimationCurve curve, float progress) => Mathf.Lerp(MinRate, MaxRate, curve.Evaluate(progress));
}