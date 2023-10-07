using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] grassPrefabs;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private Vector2 size = new(5, 5);
    [SerializeField] private int spawnCount;

    private void Start()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Vector3 grassPos = new Vector3(Random.Range(0, size.x), 0, Random.Range(0, size.y));
            SpawnGrass(grassPos);
        }
    }

    private void SpawnGrass(Vector3 position)
    {
        GameObject enemy = grassPrefabs[Random.Range(0, grassPrefabs.Length)];
        Instantiate(enemy, position, Quaternion.identity, transform);
    }
}
