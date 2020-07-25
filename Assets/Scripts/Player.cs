using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CapsuleColliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{

    //移動スピード
    [SerializeField] float speed = 2f;


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
        caps.center = new Vector3(0, 0, 0);
        //CapsuleColliderの半径を決める
        caps.radius = 0.5f;
        //CapsuleColliderの高さを決める
        caps.height = 2f;
    }

    void Update()
    {
        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

     
        //前移動の時だけ方向転換をさせる
        if (z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        transform.position += transform.forward * z + transform.right * x;
    }
}