using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public GameObject PopupRuleCanvas;
    public Canvas Canvas;
    public GameObject SceneManage;
    public FadeManager fade;
    public AudioClip enter;
    public AudioClip cancel;
    public AudioClip Pinpon;
    public AudioSource audiosource;
   

   
    private void Start()
    {
        
        Canvas = PopupRuleCanvas.GetComponent<Canvas>();
        Canvas.enabled =false;
        fade = SceneManage.GetComponent<FadeManager>();
        FadeManager.FadeIn();
    }

    public void OnClickStartButton()//始めるボタンが押されたとき
    {
        audiosource.PlayOneShot(Pinpon);
        Canvas.enabled = true;
    }
    public void OnClickSettingButton()//設定ボタンが押されたとき
    {
        audiosource.PlayOneShot(enter);
        FadeManager.FadeOut(1);
    }
    public void OnClickResultButton()//リザルトボタンが押されたとき
    {
        audiosource.PlayOneShot(enter);
        FadeManager.FadeOut(2);

    }

    public void OnClickBackButton()//タイトルに戻りたい時
    {
        audiosource.PlayOneShot(cancel);
        FadeManager.FadeOut(0);

    }
    public void OnClickYesButton()//始めるボタンが押されたとき
    {
        audiosource.PlayOneShot(enter);
        SceneManager.LoadScene("");
    }
    public void OnClickNoButton()//始めるボタンが押されたとき
    {
        audiosource.PlayOneShot(cancel);
        FadeManager.FadeOut(3);
       // SceneManager.LoadScene("map2Scene");
    }
    //　ゲーム終了ボタンを押したら実行する
    public void EndGame()
    {
        audiosource.PlayOneShot(cancel);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }


}


// class TestController
