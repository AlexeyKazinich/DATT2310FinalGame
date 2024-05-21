using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnAreaMin; //min coords of the spawn area
    public Vector2 spawnAreaMax; //max coords of the spawn area
    // Start is called before the first frame update
    public void SpawnEnemies(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        Instantiate(enemyPrefab, randomPosition,Quaternion.identity);
    }

    
}
