﻿using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health Health;

    public LayerMask DamageLayer;
    public float MoveSpeed = 1;
    public float AttackRange = 2;

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
        var cam = Camera.main.transform;
        var target = cam.position;
        var dist = Vector3.Distance(transform.position, target);

        transform.LookAt(target);

        if (dist > AttackRange)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            Attack();
        }

        // Substitute this with colliders or smaller compartments to allow special hitting spots
        var hits = Physics.OverlapSphere(transform.position, ColliderRadius, DamageLayer);

        if (hits.Length > 0)
        {
            var arrow = hits[0].GetComponentInParent<Arrow>();
            Destroy(arrow.gameObject);

            Health.TakeDamage();
        }
    }

    private void Attack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ColliderRadius);
    }
}