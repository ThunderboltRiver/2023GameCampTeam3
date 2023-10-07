using UnityEngine;
[System.Serializable]
public class GrassData
{
    [SerializeField]private GameObject prefab; // 生成する草のプレハブ
    [SerializeField]private int weight; // 出現率
    public GameObject Prefab => prefab;
    public int Weight => weight;
}