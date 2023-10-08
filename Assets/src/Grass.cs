using UnityEngine;
[System.Serializable]
public class GrassData
{
    [SerializeField]private GameObject prefab; // 生成する草のプレハブ
    [SerializeField]private int weight; // 出現率
    [SerializeField]private int scorePoint; // 草を刈ったときに得られるスコア
    public GameObject Prefab => prefab;
    public int Weight => weight;
    public int ScorePoint => scorePoint;
}