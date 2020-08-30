using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageCanvas : MonoBehaviour
{

    [SerializeField] GameObject pauseCanvas;
    public GameObject instanceCancvas;
    bool isClick;

    public GameObject AxisObject;

    public Axis cam;
    // Start is called before the first frame update
    void Start()
    {//初期化
        
        isClick = false;
        cam = AxisObject.gameObject.GetComponent<Axis>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isClick == false)
        {//エスケープが押されたらポーズする
            pauseCanvas.SetActive(true);
            
            Time.timeScale = 0f;//時間を止める
            cam.enabled = false;//カメラを停止
            isClick = true;
        }
    }

   public void OnclickBackButton()
    {
        pauseCanvas.SetActive(false);
        //カーソル固定非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1f;//時間を再開
        cam.enabled = true;//カメラを再生
        isClick = false;//重複防止
    }

   public void OnclickBackTitleButton()
    {


        SceneManager.LoadScene("TitleScreen");
    }


}
