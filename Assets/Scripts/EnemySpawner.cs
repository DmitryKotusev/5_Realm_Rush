using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenSpawns = 3f;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    Transform spawnInfo;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(enemyPrefab, spawnInfo.position, spawnInfo.rotation, transform);
        }
    }
}
