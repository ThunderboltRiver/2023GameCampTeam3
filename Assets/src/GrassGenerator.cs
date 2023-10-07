using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassGenerator : MonoBehaviour
{
    [Header("Generate Setting")]
    [SerializeField] private Vector2 size;
    [SerializeField] private int timeInterval;
    [SerializeField] private int generateThreshold;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] GrassData[] grassDatas;
    //[SerializeField] Score score;
    [Header("Key Bindings")]
    [SerializeField] private KeyCode reGenerate = KeyCode.R;

    private float time;
    private int generateCount;

    private void Update()
    {
        if (Input.GetKeyDown(reGenerate))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime; // 時間を加算
        var totalSeconds = Mathf.Round(time); // 経過時間のうち秒数だけ取得
        if (totalSeconds % timeInterval == 0) // 一定時間ごとに作成
        {
            GenerateGrass(increaseCoefficient: totalSeconds / timeInterval);
            return;
        }
    }

    private void GenerateGrass(float increaseCoefficient)
    {
        var totalGrassWeight = grassDatas.Aggregate(0, (current, grassData) => current + grassData.Weight); // 出現率の合計を取得
        foreach (var grassData in grassDatas)
        {
            var grassProbability = grassData.Weight / totalGrassWeight; // 出現率を確率に変換
            var generateNum = grassProbability + increaseCoefficient; // 確率に応じて生成数を決定
            for (var i = 0; i < generateNum; i++)
            {
                var generatePosition = new Vector3(Random.Range(-size.x, size.x), 0, Random.Range(-size.y, size.y));
                SpawnGrass(grassData.Prefab, generatePosition);
            }
        }

    }

    private void SpawnGrass(GameObject grass,Vector3 position)
    {
        if(generateCount >= generateThreshold) return;
        Instantiate(grass, position, Quaternion.identity, transform);
        generateCount++;
    }
}
