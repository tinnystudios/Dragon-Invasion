using UnityEngine;

public static class DataBinderExtensions
{
    public static void Bind<T, TGet>(this MonoBehaviour mono, TGet dependent = null) where T : class, IBind<TGet> where TGet : class
    {
        var dependencies = mono.GetComponentsInChildren<T>(includeInactive: true);

        if (dependent == null)
            dependent = mono.GetComponentInChildren<TGet>(includeInactive: true);

        if (dependent == null && dependencies.Length > 0)
        {
            Debug.LogError($"Could not bind {typeof(TGet)} from {mono.name}", mono);
            return;
        }

        foreach (var dependency in dependencies)
            dependency.Bind(dependent);
    }
}
