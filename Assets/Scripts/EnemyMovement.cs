using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float movementPeriod = 0.5f;
    [SerializeField]
    GameObject selfDestructParticles;

    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        foreach(WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        GameObject deathParticlesInstance
            = Instantiate(selfDestructParticles, transform.position, Quaternion.identity);
        Destroy(deathParticlesInstance, deathParticlesInstance.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}
