using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    Transform objectToPan;  
    [SerializeField]
    float attackRange = 30f;
    [SerializeField]
    ParticleSystem projectile;

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length <= 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        for (int i = 1; i < sceneEnemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, sceneEnemies[i].transform.position) < Vector3.Distance(transform.position, closestEnemy.position))
            {
                closestEnemy = sceneEnemies[i].transform;
            }
        }

        targetEnemy = closestEnemy;
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
