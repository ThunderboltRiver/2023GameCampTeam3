using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    Collider _collider;//鎌のCollider

    private void Start()
    {
        ///<summary>
        ///鎌のColliderを取得
        ///鎌はプレイヤーの最初のこオブジェクトにしてくれ！
        /// </summary>
        _collider = transform.GetChild(0).gameObject.GetComponent<Collider>();
        _collider.enabled = false;
    }

    public void CollisionDetectionOn()
    {
        //当たり判定をON
        _collider.enabled = true;
    }

    public void CollisionDetectionOff()
    {
        //当たり判定をOFF
        _collider.enabled = false;
    }

}