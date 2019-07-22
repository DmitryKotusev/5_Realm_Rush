using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenSpawns = 3f;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    Transform spawnInfo;
    [SerializeField]
    Text enemyCountText;
    [SerializeField]
    AudioClip spawnEnemySFX;
    int score;

    private void Start()
    {
        enemyCountText.text = score.ToString();
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            AddScore();
            Instantiate(enemyPrefab, spawnInfo.position, spawnInfo.rotation, transform);
        }
    }

    private void AddScore()
    {
        score++;
        enemyCountText.text = score.ToString();
    }
}
