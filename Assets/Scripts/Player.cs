using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CapsuleColliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{

    //移動スピード
    [SerializeField] float speed = 4f;

    //ダッシュ時のスピード倍率
    [SerializeField] float DashSpeed = 2f;


    //前進しているかを整数で判定する変数

    bool walk;
    //Main Cameraを入れる
    [SerializeField] Transform cam;

    //Rigidbodyを入れる
     Rigidbody rb;
    //Capsule Colliderを入れる
     CapsuleCollider caps;

    void Start()
    {
        

        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        //RigidbodyのConstraintsを3つともチェック入れて
        //勝手に回転しないようにする
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //CapsuleColliderコンポーネントを取得
        caps = GetComponent<CapsuleCollider>();
        //CapsuleColliderの中心の位置を決める
        caps.center = new Vector3(0, 0.07f, 0);
        //CapsuleColliderの半径を決める
        caps.radius = 0.03f;
        //CapsuleColliderの高さを決める
        caps.height = 0.12f;
    }

    void Update()
    {
        Walking();
    }

    void Walking()
    {
        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        //Debug.Log(Time.deltaTime);


        //前進しているか判定
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
        //Debug.Log(Input.GetKey(KeyCode.LeftShift));
        // Debug.Log(walk);

        //前移動の時だけ方向転換をさせる
        if (z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        //前進していてかつShiftが押されているとダッシュ倍率をかける。そうでなければ通常速度
        if (walk == true && Input.GetKey(KeyCode.LeftShift) == true)
        {
            transform.position += transform.forward * z * DashSpeed + transform.right * x;
        }
        else
        {
            transform.position += transform.forward * z + transform.right * x;
        }

        // Debug.Log(z);


    }
}