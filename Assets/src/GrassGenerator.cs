using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] grassPrefabs;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] Grass[] grasses;

    [Header("Generate Setting")]
    [SerializeField] private Vector2 size = new(5, 5);
    [SerializeField] private int spawnCount;
    private int currentNum = 0;

    [Header("Key Bindings")]
    [SerializeField] private KeyCode reGenerate = KeyCode.R;

    private void Start()
    {
        SpawnStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(reGenerate))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SpawnStart()
    {
        foreach (Grass g in grasses)
        {
            for (int i = 0; i < spawnCount * g.rate; i++)
            {
                Vector3 grassPos = new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.y / 2, size.y / 2));
                SpawnGrass(grassPos);
            }
            currentNum++;
        }
    }

    private void SpawnGrass(Vector3 position)
    {
        GameObject enemy = grassPrefabs[currentNum];
        Instantiate(enemy, position, Quaternion.identity, transform);
    }
}
