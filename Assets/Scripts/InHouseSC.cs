using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseSC : MonoBehaviour
{
    public GameObject gamemanager;
    public GameSystem gamesystem;

    bool isexit;
    public GameObject Axis;
    public Axis cameraScript;
    public AudioSource audiosource;
    public AudioClip enter;
    public AudioClip cansel;

    // Start is called before the first frame update
    void Start()
    {
        isexit = true;
        cameraScript = Axis.GetComponent<Axis>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)//家のコライダーに入った時
    {
        if (other.CompareTag("Player") == true && gamesystem.Key == false && isexit == true)//踏んだコライダーのタグがPlayerタグだった場合
        {
            Debug.Log("鍵がないと家に入れません鍵を手に入れましょう");


        }
        else if (other.CompareTag("Player") == true && gamesystem.Key == true && isexit == true)
        {
            isexit = false;

            Debug.Log("家に入りますか？");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;//時間を止める
            cameraScript.enabled = false;//カメラを停止
            Debug.Log("家に入った");
            audiosource.PlayOneShot(enter);

            Time.timeScale = 1f;//時間を再開

            gamesystem.InHouse = true;


        }
    }
}
  
