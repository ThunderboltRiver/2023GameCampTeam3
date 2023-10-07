using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    Vector3 currentPos;//プレイヤーの現在の位置
    Vector3 pastPos;//プレイヤーの過去の位置

    Vector3 diff;//位置の差

    [SerializeField]
    [Tooltip("-90～90")]
    private float MaxAngle;

    [SerializeField]
    [Tooltip("-90～90")]
    private float MinAngle;

    private void Start()
    {
        //最初のプレイヤーの位置を取得
        pastPos = player.transform.position;

        //カーソルを消す！
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //プレイヤーの現在値を取得
        currentPos = player.transform.position;

        diff = currentPos - pastPos;

        transform.position += diff;//プレイヤーの移動分だけカメラを移動させる

        pastPos = currentPos;

        // 現在のプレイヤーのX軸方向の角度を取得
        float currentXAngle = transform.localEulerAngles.x;

        if (currentXAngle > 180)
        {
            // デフォルトでは角度は0～360なので-180～180となるように補正
            currentXAngle = currentXAngle - 360;
        }

        //マウスの入力を取得
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //カメラの横移動
        if (Mathf.Abs(mx) > 0.01f)
        {
            //プレイヤーを中心に、マウスの横入力分回転させる
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

        //カメラの縦移動
        if((currentXAngle >= MinAngle && my > 0.01f) || (currentXAngle <= MaxAngle && my < -0.01f))
        {
            //プレイヤーを中心に、マウスの縦入力分回転させる
            transform.RotateAround(player.transform.position, transform.right, -my);
        }

        if(currentXAngle < MinAngle || currentXAngle > MaxAngle)
        {
            //transform.RotateAround(player.transform.position, transform.right, MinAngle - currentXAngle);
        }
    }
}
