using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    //*------------*//
    void Start()
    {

        actiontxt.gameObject.SetActive(false);//テキストを非表示にする
        repeatedhitstxt.gameObject.SetActive(false);




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


    }

    void Update()
    {
        Walking();

    }
    void LateUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)//イベント1用インターホンのコライダーに入った時
    {
        if (other.CompareTag("Event") == true )//踏んだコライダーのタグがEventタグだった場合
        {
            
            actiontxt.gameObject.SetActive(true);//クリックでインターホンを連打 を表示
            repeatedhitstxt.gameObject.SetActive(true);//連打回数を表示
            


            tmpEvent = other.gameObject;    //EventプレハブをローカルのGameObject変数に入れる

            ParentEvent = other.transform.parent.gameObject;//コライダーの親を取得

            tmpPointCanvas = ParentEvent.transform.Find("PointCanvas").GetComponent<Canvas>();

            if (Input.GetMouseButtonDown(0))  //左クリックが押されたら もしもカウントしていなかったらピンポン完了数を1増やし クリックしただけPinponCounterに入れる
            {
                Debug.Log("クリック!");
                pinpontotal++;
                PinponCounter++;
                repeatedhitstxt.text = "" + PinponCounter;

                if (counted == true)
                {
                    PinponCount = PinponCount + 1;
                    counted = false;
                }
            }



            Debug.Log("ピンポンを連打");
            Debug.Log(PinponCounter);
            Debug.Log(PinponCount);
            Debug.Log(hitstotal);

            Invoke("DestroyEvent",3); //3秒後にDestroyEventを実行 ↓↓

        }



    }

    void DestroyEvent()
    {
        actiontxt.gameObject.SetActive(false);   //上部で表示したテキストを非表示
        repeatedhitstxt.gameObject.SetActive(false);
        //ピンポン連打数を保存して合計を計算
        hitstotal = hitstotal + int.Parse(repeatedhitstxt.text);
        //テキストに入れるカウント数を0に戻して初期化
        repeatedhitstxt.text = "0";
        PinponCounter = 0;

        tmpPointCanvas.gameObject.SetActive(false);
        tmpEvent.gameObject.SetActive(false);            //ピンポンしたEventプレハブを消す
        counted = true;                 //ピンポン完了数が一度に2以上加算されないためにtrueにする
        

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
}