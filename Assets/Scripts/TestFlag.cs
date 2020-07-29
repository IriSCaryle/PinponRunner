using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlag : MonoBehaviour
{

    GameObject testgamemanager;

    GameSystem testflagscript;
    // Start is called before the first frame update
    void Start()
    {
        //GameSystemの変数を取得するためにオブジェクトとスクリプトを取得
        testgamemanager = GameObject.Find("GameManager");
        testflagscript = testgamemanager.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            Debug.Log("MissionをCompreteにしますか？");

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ミッションコンプリート");
                
                testflagscript.MissionComprete = true;
            }
        }
    }
}
