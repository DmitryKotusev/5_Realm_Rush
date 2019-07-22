using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    int hitPoints = 10;
    [SerializeField]
    GameObject deathParticles;
    [SerializeField]
    GameObject hitParticles;
    [SerializeField]
    AudioClip hitSFX;
    [SerializeField]
    AudioClip deathSFX;
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject deathParticlesInstance
            = Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(deathParticlesInstance, deathParticlesInstance.GetComponent<ParticleSystem>().main.duration);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        GameObject hitParticlesInstance
            = Instantiate(hitParticles, transform.position, Quaternion.identity);
        Destroy(hitParticlesInstance, 2f);
        GetComponent<AudioSource>().PlayOneShot(hitSFX);
        hitPoints--;
    }
}
