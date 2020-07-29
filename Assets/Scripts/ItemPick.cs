using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{

    GameObject gamemanager;

    GameSystem flagscript;
    


    // Start is called before the first frame update
    void Start()
    {
        //GameSystemの変数を取得するためにオブジェクトとスクリプトを取得
        gamemanager = GameObject.Find("GameManager");
        flagscript = gamemanager.GetComponent<GameSystem>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    
    //OnTrigger関数
    //接触したオブジェクトが引数otherとして渡される
    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            GetComponent<Renderer>().material.color = Color.red;

            Debug.Log("アイテムを拾いますか");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("アイテムを入手した");
                Destroy(this.gameObject);
                flagscript.Key = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}