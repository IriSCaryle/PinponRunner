using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public GameObject PopupRuleCanvas;
    public Canvas Canvas;

    private void Start()
    {
        Canvas = PopupRuleCanvas.GetComponent<Canvas>();
        Canvas.enabled =false;
    }

    public void OnClickStartButton()//始めるボタンが押されたとき
    {
        
        Canvas.enabled = true;
    }
    public void OnClickSettingButton()//設定ボタンが押されたとき
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void OnClickResultButton()//リザルトボタンが押されたとき
    {
        SceneManager.LoadScene("ResultScene");

    }

    public void OnClickBackButton()//タイトルに戻りたい時
    {
        SceneManager.LoadScene("TitleScreen");

    }
    public void OnClickYesButton()//始めるボタンが押されたとき
    {
        SceneManager.LoadScene("");
    }
    public void OnClickNoButton()//始めるボタンが押されたとき
    {
        SceneManager.LoadScene("map2Scene");
    }

}


 // class TestController
