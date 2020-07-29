using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    //ブール値でゲームのフラグの変数を作成
    public bool Key;
    public bool MissionComprete;
    public bool KeyGetted;
    // Start is called before the first frame update
    void Start()
    {

        //変数の初期化
        Key = false;

        MissionComprete = false;

        KeyGetted = false;

        

       

    }

    // Update is called once per frame
    void Update()
    {
        MissionComp();
       
    }

    void MissionComp()
    {

      
        if (MissionComprete == true && KeyGetted == false)
        {

            
            KeyGetted = true;
            //ResourcesフォルダからItemPrefabをロードする
            GameObject obj = (GameObject)Resources.Load("Item");
            // プレハブを元にオブジェクトを生成する
            GameObject instance = (GameObject)Instantiate(obj,
                                                          new Vector3(5.0f, 1.0f, 0.0f),
                                                          Quaternion.identity);
        }

    }
}
