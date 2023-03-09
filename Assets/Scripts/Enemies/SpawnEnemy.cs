using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that spawns enemies

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float spawnRate = 3.0f;
    private const int Range = 10;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            var position = transform.position;
            Vector3 newPosition = new Vector3(position.x + Random.Range(-Range, Range), position.y, position.z + Random.Range(-Range, Range));
            Instantiate(enemies[Random.Range(0, enemies.Count)], newPosition, transform.rotation);
        }
    }
}

