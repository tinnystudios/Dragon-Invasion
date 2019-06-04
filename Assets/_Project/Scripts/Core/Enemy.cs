using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DragonContextProvider DragonContextProvider;
    public Health Health;

    public GameObject HitEffect;
    public LayerMask DamageLayer;

    public float ColliderRadius = 0.5F;

    public Action<Enemy> OnDeath { get; set; }

    private void Awake()
    {
        Health.OnHealthDepleted += OnHealthDepleted;
    }

    private void OnHealthDepleted()
    {
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        DetectHit();
    }

    public void Bind(BowHeroCharacter bowHeroCharacter)
    {
        var enemyContext = new EnemyContextArgs() { Player = bowHeroCharacter };
        DragonContextProvider.Bind(enemyContext);
    }

    public void DetectHit()
    {
        var hits = Physics.OverlapSphere(transform.position, ColliderRadius, DamageLayer);

        if (hits.Length > 0)
        {
            var arrow = hits[0].GetComponentInParent<Arrow>();
            Instantiate(HitEffect, arrow.transform.position, Quaternion.identity);
            Destroy(arrow.gameObject);

            Health.TakeDamage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ColliderRadius);
    }
}