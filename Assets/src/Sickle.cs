using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    Collider _collider;//鎌のCollider

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //当たり判定をON
            CollisionDetectionOn();
            Debug.Log("当たり判定ON");
            return;
        }
        //当たり判定をOFF
        CollisionDetectionOff();
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