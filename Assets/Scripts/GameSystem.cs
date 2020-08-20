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
    public int Event1Count = 3;
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

    // Start is called before the first frame update
    void Start()
    {

        //変数の初期化
        Key = false;
        //イベント１確認bool
        MissionComprete = false;
        //イベント2確認bool
        KeyGetted = false;
        //イベント2テキスト非表示
        Event2Text.gameObject.SetActive(false);
        
        Mission1inti();

       

    }

    void Mission1inti() //イベント1のテキストを初期化
    {
        Event1CompText.text = "0/0";
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

      
        if (MissionComprete == true && KeyGetted == false)
        {

            
            KeyGetted = true;
            //ResourcesフォルダからkeyPrefabをロードする
            GameObject obj = (GameObject)Resources.Load("key_pivot");
            // プレハブを元にオブジェクトを生成する
            GameObject instance = (GameObject)Instantiate(obj,
                                                          new Vector3(5.0f, 1.0f, 0.0f),
                                                          Quaternion.identity);
        }

    }
}
