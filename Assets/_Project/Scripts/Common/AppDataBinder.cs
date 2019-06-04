using UnityEngine;

/// <summary>
/// Inject useful data into IBind<T>
/// </summary>
public class AppDataBinder : MonoBehaviour
{
    public bool BindOnAwake = false;

    private void Awake()
    {
        if (BindOnAwake)
            Bind();
    }

    public void Bind()
    {
        this.Bind<IBind<App>, App>();
        this.Bind<IBind<StageRunner>, StageRunner>();
        this.Bind<IBind<BowHeroCharacter>, BowHeroCharacter>();
    }
}