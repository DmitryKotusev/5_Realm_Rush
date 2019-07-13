using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<WayPoint> path;
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
