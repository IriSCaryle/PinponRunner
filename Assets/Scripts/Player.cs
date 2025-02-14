﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//CapsuleColliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    //*プレイヤー関連*//

    //移動スピード
    public float speed = 4f;

    //ダッシュ時のスピード倍率
    public float DashSpeed = 2f;


    //前進しているかを整数で判定する変数

    public bool walk;
    //Main Cameraを入れる
    [SerializeField] Transform cam;

    //Rigidbodyを入れる
     Rigidbody rb;
    //Capsule Colliderを入れる
     CapsuleCollider caps;



    //*-------------*//

    //*イベント1関連*//

    

    //連打指示のテキストを入れる変数
    public GameObject actiontxt;
    //連打回数のテキストを入れる変数
    public Text repeatedhitstxt;
    //全ピンポン連打数の保存先変数
    public int hitstotal;


    //ピンポンの回数の変数
    public int PinponCounter;
    //otherで受け取ったEventプレハブを一時的に入れておく変数  *Inspectorには何も入れないで！！！
     GameObject tmpEvent;
    //canvasの親を取得
    GameObject ParentEvent;
    //Canvasを非表示にするために入れる変数
    Canvas tmpPointCanvas;
    //ピンポンし終わった回数
    public int PinponCount;
    //すでにカウントしてないか判定
    public bool counted;
    //スタミナゲージに走っているか渡すためのブール変数
    public bool run;
    //ピンポンの回数をゲージに送る変数
    public int pinpontotal;
    //プレハブが消えたかを確認する変数
    public bool DestroyComp;

    float second;

    public GameObject eventmanager;
    public GameSystem eventsys;

    public Vector3 ColliderPos;
    public GameObject obj;
    public bool spawnenemy;
    //*------------*//


    //音声


    public AudioSource audiosource;
    public AudioSource player_audiosource;
    public AudioClip pinpon;
    public AudioClip player_walk;
    public AudioClip player_run;
    void Start()
    {

        actiontxt.gameObject.SetActive(false);//テキストを非表示にする
        repeatedhitstxt.gameObject.SetActive(false);


        eventsys = eventmanager.GetComponent<GameSystem>();

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

        //ピンポンの回数の初期化
        PinponCounter = 0;
        pinpontotal = 0;
        counted = true;
        run = false;
        walk = false;
        DestroyComp = false;
        
    }

    void Update()
    {
        Walking();
        
    }
    void LateUpdate()
    {
        
    }
   
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") == true)
        {

           eventsys.GameOver();
        }
    }
    private void OnTriggerStay(Collider other)//イベント1用インターホンのコライダーに入った時
    {
        if (other.CompareTag("Event") == true && counted == true )//踏んだコライダーのタグがEventタグだった場合
        {
            
            actiontxt.gameObject.SetActive(true);//クリックでインターホンを連打 を表示
            repeatedhitstxt.gameObject.SetActive(true);//連打回数を表示

            ColliderPos = other.gameObject.transform.position;
            tmpEvent = other.gameObject;    //EventプレハブをローカルのGameObject変数に入れる

            ParentEvent = other.transform.parent.gameObject;//コライダーの親を取得

            tmpPointCanvas = ParentEvent.transform.Find("PointCanvas").GetComponent<Canvas>();
             second += Time.deltaTime;
           if (Input.GetMouseButtonDown(0))  //左クリックが押されたら もしもカウントしていなかったらピンポン完了数を1増やし クリックしただけPinponCounterに入れる
            {
                Debug.Log("クリック!");
                audiosource.PlayOneShot(pinpon);
                pinpontotal++;
               PinponCounter++;
                repeatedhitstxt.text = "" + PinponCounter;

                
            }

            
            if (second >= 3)
            {
                DestroyEvent();
                if (DestroyComp)
                {
                    PinponCount = PinponCount + 1;
                    DestroyComp = false;
                }
                second = 0;
            }
            Debug.Log("ピンポンを連打");
            Debug.Log(PinponCounter);
            Debug.Log(PinponCount);
            Debug.Log(hitstotal);
            
            
            

        }



    }

    void DestroyEvent()
    {
       
        
        Debug.Log("実行された");
        actiontxt.gameObject.SetActive(false);   //上部で表示したテキストを非表示
        repeatedhitstxt.gameObject.SetActive(false);
        //ピンポン連打数を保存して合計を計算
        hitstotal = hitstotal + int.Parse(repeatedhitstxt.text);
        //テキストに入れるカウント数を0に戻して初期化
        repeatedhitstxt.text = "0";
        PinponCounter = 0;

        tmpPointCanvas.gameObject.SetActive(false);
        tmpEvent.gameObject.SetActive(false);            //ピンポンしたEventプレハブを消す

        Invoke("EnemySpawn", 2);

        
        counted = true;                 //ピンポン完了数が一度に2以上加算されないためにtrueにする

        DestroyComp = true;

        
        



    }

    void EnemySpawn()
    {
        obj = (GameObject)Resources.Load("enemy03 1");
        Instantiate(obj, ColliderPos, Quaternion.identity);

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
        else if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            walk = true;
        }
        else if((Input.GetAxisRaw("Vertical") == 0) && (Input.GetAxisRaw("Horizontal") == 0))
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
            walk = false;
            transform.position += transform.forward * z * DashSpeed + transform.right * x;
            run = true;
        }
        else
        {
            transform.position += transform.forward * z + transform.right * x;
            run = false;
        }

        // Debug.Log(z);
        //Debug.Log(walk);

    }
    void WalkingSound()
    {
       
        player_audiosource.PlayOneShot(player_walk);
        
        
        
        
    }
    void RunningSound()
    {
        
        player_audiosource.PlayOneShot(player_run);
    }
    void StoppingSound()
    {
        player_audiosource.Stop();
    }
 }