using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    //ブール値でゲームのフラグの変数を作成
    public bool Key;
    public bool MissionComprete;
    public bool KeyGetted;



    //UIのプレハブ

    [SerializeField]
    GameObject clearCanvasPrefab; //クリアしたときの画面のプレハブ
    [SerializeField]
    GameObject gameOverCanvasPrefab;//ゲームオーバーしたときのプレハブ

    //カウントダウン用の変数
    [System.NonSerialized]
    public bool countDown = false;

    //デバッグモード
    public bool isDebugMode;

    //イベント1の最大数
    public int Event1Count = 4;
    //イベント1完了数
    public int Event1Counter;
    //プレイヤーオブジェクト
    public GameObject player;
    //プレイヤーのスクリプト
    public Player playerscript;
    //イベント1完了数テキスト
    public Text Event1CompText;
    //イベント2テキスト
    public Text Event2Text;
    //イベント1テキスト
    public Text Event1Text;

    //*イベント1のポイントの変数*//

        //各エリアの変数
    public GameObject Area1;
    public GameObject Area2;
    public GameObject Area3;
    public GameObject Area4;
    //各エリアのオブジェクト数
    int numArea1;
    int numArea2;
    int numArea3;
    int numArea4;

    public GameObject[] Area1_point = new GameObject[5]; 
    public GameObject[] Area2_point = new GameObject[5];
    public GameObject[] Area3_point = new GameObject[4];
    public GameObject[] Area4_point = new GameObject[4];

    int numcount;//番号を入れる変数

    int randomnum1;
    int randomnum2;
    int randomnum3;
    int randomnum4;

    //イベント1の候補
    public GameObject[] EventPoint = new GameObject[4];


    //ピンのローカル座標
    public Vector3 PointPosition;


   
    //ピンのキャンバス変数
    public Canvas Point1;
    public Canvas Point2;
    public Canvas Point3;
    public Canvas Point4;

    //*イベント2関連*//

    public GameObject PlayerHome;//プレイヤーの家（ここに入ると終わる）変数
    public GameObject KeyObject;//キーオブジェクト

   
    


    // Start is called before the first frame update
    void Start()
    {
        KeyGetted = false;
        //変数の初期化
        Key = false;
        //イベント１確認bool
        MissionComprete = false;
        //イベント2確認bool
        KeyGetted = false;
        //イベント2テキスト非表示
        Event2Text.gameObject.SetActive(false);
        
        Mission1inti();
        Mission2inti();

       

    }

    void Mission1inti() 
        //イベント1のテキストを初期化
    {
        numcount = 0;
        Event1CompText.text = "0/0";

    

        //Area1のオブジェクトのtransformを取得
        foreach (Transform childTransform in Area1.transform)
        {
            if (childTransform.gameObject.CompareTag("Target"))//Targetがついているオブジェクトのみ取得
            {
                
                Area1_point[numcount] = childTransform.gameObject; //エリア1の配列に今数えている数番目の場所に代入
                Debug.Log("Area1 is " + childTransform.gameObject.name + " " + numcount + "番目に代入されました") ;//わかりやすいようにコンソール表示
                numArea1 += 1;//numを増やす
                numcount += 1;


            }
        }
        numcount = 0;//他で利用するのでいったんリセット

        //Area2のオブジェクトのtransformを取得
        foreach (Transform childTransform2 in Area2.transform)
        {
            if (childTransform2.gameObject.CompareTag("Target"))//Targetがついているオブジェクトのみ取得
            {
                Area2_point[numcount] = childTransform2.gameObject; //エリア2の配列に今数えている数番目の場所に代入
                Debug.Log("Area2 is " + childTransform2.gameObject.name + " " + numcount + "番目に代入されました");//わかりやすいようにコンソール表示
                numArea2 += 1;
                numcount += 1;
            }
        }
        numcount = 0;


        //Area3のオブジェクトのtransformを取得
        foreach(Transform childTransform3 in Area3.transform)
        {
            if (childTransform3.gameObject.CompareTag("Target"))////Targetがついているオブジェクトのみ取得
            {
                Area3_point[numcount] = childTransform3.gameObject; //エリア1の配列に今数えている数番目の場所に代入
                Debug.Log("Area3 is " + childTransform3.gameObject.name + " " + numcount  + "番目に代入されました") ;//わかりやすいようにコンソール表示
                numArea3 += 1;
                numcount += 1;
            }

        }
        numcount = 0;


        //Area4のオブジェクトのtransformを取得
        foreach (Transform childTransform4 in Area4.transform)
        {
            if (childTransform4.gameObject.CompareTag("Target"))////Targetがついているオブジェクトのみ取得
            {
                Area4_point[numcount] = childTransform4.gameObject; //エリア1の配列に今数えている数番目の場所に代入

                Debug.Log("Area4 is " + childTransform4.gameObject.name + " " + numcount + "番目に代入されました");//わかりやすいようにコンソール表示
                numArea4 += 1;
                numcount += 1;
            }

        }

        randomnum1 = Random.Range(0, 4);
        Debug.Log("エリア1" + " " + randomnum1 + "番");
        randomnum2 = Random.Range(0, 4);
        Debug.Log("エリア2" + " " + randomnum2 + "番");
        randomnum3 = Random.Range(0, 3);
        Debug.Log("エリア3" + " " + randomnum3 + "番");
        randomnum4 = Random.Range(0, 3);
        Debug.Log("エリア4" + " " + randomnum4 + "番");
        EventPoint[0] = Area1_point[randomnum1];//エリア1のランダムに選択した位置のオブジェクトを入れる
        EventPoint[1] = Area2_point[randomnum2];//エリア2
        EventPoint[2] = Area3_point[randomnum3];//エリア3
        EventPoint[3] = Area4_point[randomnum2];//エリア4


        EventPoint[0].transform.Find("DoorCollider").gameObject.SetActive(true);//候補に選ばれた家の中にあるDoorColliderというプレハブのアクティブ化
        EventPoint[1].transform.Find("DoorCollider").gameObject.SetActive(true);
        EventPoint[2].transform.Find("DoorCollider").gameObject.SetActive(true);
        EventPoint[3].transform.Find("DoorCollider").gameObject.SetActive(true);

        //*----*//
        EventPoint[0].transform.Find("PointCanvas").gameObject.SetActive(true);//ピンのアクティブ化

        Point1 = EventPoint[0].transform.Find("PointCanvas").GetComponent<Canvas>();//座標を変えるためにCanvasを取得して変数に代入

        Point1.transform.localPosition = PointPosition;
        //*----*//

        //*----*//
        EventPoint[1].transform.Find("PointCanvas").gameObject.SetActive(true);

        Point2 = EventPoint[1].transform.Find("PointCanvas").GetComponent<Canvas>();

        Point2.transform.localPosition = PointPosition;
        //*----*//

        //*----*//
        EventPoint[2].transform.Find("PointCanvas").gameObject.SetActive(true);

        Point3 = EventPoint[2].transform.Find("PointCanvas").GetComponent<Canvas>();

        Point3.transform.localPosition = PointPosition;
        //*----*//

        //*----*//
        EventPoint[3].transform.Find("PointCanvas").gameObject.SetActive(true);

        Point4 = EventPoint[3].transform.Find("PointCanvas").GetComponent<Canvas>();

        Point4.transform.localPosition = PointPosition;
        //*----*//












    }

    void Mission2inti()
    {
        

      
    }

    // Update is called once per frame
    void Update()
    {
        Mission1();
        Mission2();
       
    }


    void Mission1()//Playerのカウンターを取得してイベントの最大数と比較して処理する場所
    {
           //イベント完了数とイベント数をテキストに入れる
        Event1CompText.text = (playerscript.PinponCount + "/" + Event1Count);
        //イベントテキストの切り替え
        if(playerscript.PinponCount == Event1Count && playerscript.counted == true)
        {
            Event1Text.gameObject.SetActive(false);//イベント1の内容を非表示
            Event1CompText.gameObject.SetActive(false);//イベント1の完了数を非表示
            Event2Text.gameObject.SetActive(true);//イベント2の内容を表示
            MissionComprete = true;
            


        }

    }
    void Mission2()//
    {


        if (MissionComprete == true && KeyGetted == false && Key == false) 
        {

            
            KeyGetted = true;//キーがゲットできる状態にする
                             //keypivotを表示にする
            KeyObject.transform.Find("Key_pivot").gameObject.SetActive(true);
          
        }

        if (Key == true)
        {
            PlayerHome.transform.Find("homecollider").gameObject.SetActive(true);//ホームコライダー表示
            PlayerHome.transform.Find("HomePointCanvas").gameObject.SetActive(true);//ホームアイコン表示

        }
    }
}
