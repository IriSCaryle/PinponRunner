using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{

    public GameObject eventmanager;

    public GameSystem flagscript;
    [SerializeField] GameObject KeyCanvas;

    public GameObject AxisObject;
    public Axis camSC;
    bool isexit;



    // Start is called before the first frame update
    void Start()
    {
        isexit = true;
        //GameSystemの変数を取得するためにオブジェクトとスクリプトを取得
        eventmanager = GameObject.Find ("EventManager");
        flagscript = eventmanager.GetComponent<GameSystem>();
       camSC = AxisObject.GetComponent<Axis>();

        

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    
    //OnTrigger関数
    //接触したオブジェクトが引数otherとして渡される
    void OnTriggerStay(Collider other)
    {
        if (flagscript.MissionComprete == true && isexit == true)
        {
            
            //接触しているオブジェクトのタグが"Player"のとき
            if (other.CompareTag("Player"))
            {
                isexit = false;
                KeyCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0f;//時間を止める
                camSC.enabled = false;//カメラを停止

                Debug.Log("鍵を拾いますか");
              
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        isexit = true;
        //離れたオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を白に変更する
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void OnYesButton()
    {
        isexit = true;
        KeyCanvas.SetActive(false);
        Debug.Log("鍵を入手した");
        
        flagscript.Key = true;
        //カーソル固定非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;//時間を再開
        camSC.enabled = true;//カメラを再生
        Destroy(this.gameObject);

    }
    public void OnNoButton()
    {
        KeyCanvas.SetActive(false);

        //カーソル固定非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;//時間を再開
        camSC.enabled = true;//カメラを再生
      
    }


}