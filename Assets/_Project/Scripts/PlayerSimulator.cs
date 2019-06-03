using UnityEngine;

public class PlayerSimulator : MonoBehaviour, IBind<BowHeroCharacter>
{
    public BowHeroCharacter BowHeroCharacter { get; private set; }
    public Transform Player;
    public Arrow Arrow;

    public float MoveSpeed = 1;
    public GameObject[] HideThese;

    public void Bind(BowHeroCharacter dependent) => BowHeroCharacter = dependent;

#if UNITY_EDITOR

    private void Awake()
    {
        foreach (var g in HideThese)
        {
            g.SetActive(false);
        }
    }

    private void Update()
    {
        Player.transform.position += GameInput.Movement * MoveSpeed;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetButtonDown("Fire1"))
        {
            var pos = Vector3.zero + ray.direction * 1;

            var arrow = BowHeroCharacter.Bow.MakeArrow();

            arrow.transform.position = ray.origin;
            arrow.transform.rotation = transform.rotation;
            arrow.transform.LookAt(pos);
            arrow.Fire(10);
        }

    }
#endif
}
