using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeedIn;//設定される移動速度
    float moveSpeed;//プレイヤーの移動速度

    Rigidbody playerRb;//プレイヤーのRigidbody

    Vector3 currentPos;//現在の位置
    Vector3 pastPos;//過去の位置

    Vector3 delta;//差分

    Quaternion playerRot;//プレイヤーがどんだけ回転するか

    float currentAngularVelocity;//現在の速度を格納する

    float maxAngularVelocity = Mathf.Infinity;//回転の最大速度[deg/s]

    [SerializeField]
    float smoothTime = 0.1f;//目標値に到達するまでのおおよその時間[s]

    float diffAngle;//差分に対してどんくらい回転するか

    float rotAngle;//回転

    Quaternion nextRot;//次の回転

    int moveAnim = 0;//どのアニメーションなのか
    int moveAnimSet;//歩くか、走るか

    Animator playerAnim;//プレイヤーのAnimator

    private CapsuleCollider _collider;

    bool cutting;

    void Start()
    {
        playerAnim = GetComponent<Animator>();

        playerRb = GetComponent<Rigidbody>();

        _collider = GetComponent<CapsuleCollider>();

        pastPos = transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeedIn + 80;
            moveAnimSet = 2;
        }
        else
        {
            moveSpeed = moveSpeedIn;
            moveAnimSet = 1;
        }

        //カメラの正面を取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //カメラの右方向を取得
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        currentPos = transform.position;

        delta = currentPos - pastPos;
        delta.y = 0;

        pastPos = currentPos;


        playerRot = Quaternion.LookRotation(delta, Vector3.up);

        diffAngle = Vector3.Angle(transform.forward, delta);

        rotAngle = Mathf.SmoothDampAngle(0, diffAngle, ref currentAngularVelocity, smoothTime, maxAngularVelocity);

        nextRot = Quaternion.RotateTowards(transform.rotation, playerRot, rotAngle);

        transform.rotation = nextRot;

        //左クリックで刈る
        if (Input.GetMouseButton(0))
        {
            playerAnim.SetTrigger("Cut");
            cutting = true;
        }

        if (GetNormalVectorOnPlane() != null)
        {
            playerRb.isKinematic = false;

            var direction = Vector3.zero;

            if (cutting == false)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    direction += moveSpeed * cameraForward;

                }

                if (Input.GetKey(KeyCode.A))
                {
                    direction += -moveSpeed * cameraRight;
                }


                if (Input.GetKey(KeyCode.S))
                {
                    direction += -moveSpeed * cameraForward;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    direction += moveSpeed * cameraRight;
                }
            }

            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                return;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                return;
            }

            MoveToInputedDirection(direction);

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                playerRb.isKinematic = true;
                moveAnim = 0;
            }

            if(cutting == true)
            {
                playerRb.isKinematic = true;
            }

            
        } 

        //アニメーション
        playerAnim.SetInteger("Move", moveAnim);

    }

    public Vector3? GetNormalVectorOnPlane()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(_collider.transform.position, _collider.radius, Vector3.down,
        out hitInfo, _collider.height / 2f - _collider.radius + 0.01f))
        {
            return hitInfo.normal;
        }
        return null;

    }

    private void MoveToInputedDirection(Vector3 inputed)
    {
        playerRb.AddForce(inputed - playerRb.velocity / Time.fixedDeltaTime, ForceMode.Acceleration);
        moveAnim = moveAnimSet;
    }

    public void CutEnd()
    {
        cutting = false;
        Debug.Log("hoge");
    }

}
