using UnityEngine;

/// <summary>
/// Inject useful data into IBind<T>
/// </summary>
public class AppDataBinder : MonoBehaviour
{
    public void Bind()
    {
        this.Bind<IBind<App>, App>();
        this.Bind<IBind<StageRunner>, StageRunner>();
    }
}