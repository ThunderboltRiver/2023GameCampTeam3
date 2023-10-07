using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassGenerator : MonoBehaviour
{
    [Header("Generate Setting")]
    [SerializeField] private Vector2 size = new(5, 5);
    [SerializeField] private int spawnCount;
    [SerializeField] private int timeInterval = 20;
    private int currentNum = 0;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] grassPrefabs;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] Grass[] grasses;
    //[SerializeField] Score score;

    [Header("Key Bindings")]
    [SerializeField] private KeyCode reGenerate = KeyCode.R;

    private float time;

    private void Update()
    {
        if (Input.GetKeyDown(reGenerate))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (Mathf.Round(time) % timeInterval == 0)
        {
            SpawnStart();
        }
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
            if (currentNum < grasses.Length)
                currentNum++;
        }
    }

    private void SpawnGrass(Vector3 position)
    {
        GameObject grass = grassPrefabs[currentNum];
        Instantiate(grass, position, Quaternion.identity, transform);
    }
}
