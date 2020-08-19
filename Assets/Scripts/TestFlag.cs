using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlag : MonoBehaviour
{

    public GameObject testgamemanager;

    public GameSystem gamesystem;
    // Start is called before the first frame update
    void Start()
    {
        //GameSystemの変数を取得するためにオブジェクトとスクリプトを取得
       
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
                
                gamesystem.MissionComprete = true;
            }
        }
    }
}
