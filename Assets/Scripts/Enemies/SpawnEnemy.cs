using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that spawns enemies

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float initialSpawnRate = 3.0f;
    [SerializeField] private float spawnRateChange = 0.05f;
    [SerializeField] private int range = 10;
    
    private const float MinimumSpawnRate = 0.5f;
    private float spawnRate;

    // Start is called before the first frame update
    private void Start()
    {
        spawnRate = initialSpawnRate;
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            
            var position = transform.position;
            Vector3 newPosition = new Vector3(position.x + Random.Range(-range, range), position.y, position.z + Random.Range(-range, range));
            Instantiate(enemies[Random.Range(0, enemies.Count)], newPosition, transform.rotation);
            
            spawnRate -= spawnRateChange;
            if (spawnRate < MinimumSpawnRate)
            {
                spawnRate = MinimumSpawnRate;
            }
        }
    }
}

