﻿using System.Collections;
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
    private void Start()
    {
        
        Canvas = PopupRuleCanvas.GetComponent<Canvas>();
        Canvas.enabled =false;
        fade = SceneManage.GetComponent<FadeManager>();
        FadeManager.FadeIn();
    }

    public void OnClickStartButton()//始めるボタンが押されたとき
    {
        
        Canvas.enabled = true;
    }
    public void OnClickSettingButton()//設定ボタンが押されたとき
    {
        FadeManager.FadeOut(1);
    }
    public void OnClickResultButton()//リザルトボタンが押されたとき
    {
        FadeManager.FadeOut(2);

    }

    public void OnClickBackButton()//タイトルに戻りたい時
    {
        FadeManager.FadeOut(0);

    }
    public void OnClickYesButton()//始めるボタンが押されたとき
    {
        SceneManager.LoadScene("");
    }
    public void OnClickNoButton()//始めるボタンが押されたとき
    {
        FadeManager.FadeOut(3);
       // SceneManager.LoadScene("map2Scene");
    }
    //　ゲーム終了ボタンを押したら実行する
    public void EndGame()
    {
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
