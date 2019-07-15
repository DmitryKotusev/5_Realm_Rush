using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    Transform objectToPan;
    [SerializeField]
    Transform targetEnemy;
    [SerializeField]
    float attackRange = 30f;
    [SerializeField]
    ParticleSystem projectile;

    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool doShoot)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = doShoot;
    }
}
