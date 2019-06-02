using System;
using UnityEngine;

public abstract class ContextProviderBase<T> : ContextProviderBase, IContextProvider where T : class
{
    public T Context;

    public bool Validate
    {
        get
        {
            var isMono = Type.IsSubclassOf(typeof(MonoBehaviour));

            if (isMono && Context == null)
                Context = GetComponentInParent<T>();

            return Context != null;
        }
    }

    public Type Type => typeof(T);
}

public abstract class ContextProviderBase : MonoBehaviour
{

}