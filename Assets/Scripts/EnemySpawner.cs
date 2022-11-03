using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    private int mod;

    private void Start()
    {
        mod = 10;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            SpawnEnemy();
        }

        if (PlayerController.Instance.score % mod == 0 && PlayerController.Instance.score != 0)
        {
            secondsBetweenSpawn -= 0.1f;
            mod += 10;
        }


    }


    private void SpawnEnemy()
    {
        int randomCount = Random.Range(1, (mod / 10));

        for (int i = 0; i < randomCount; i++)
        {
            int randomPos = Random.Range(0, spawnPoints.Length - 1);

            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[randomPos].position, Quaternion.identity);
        }

    }
}
