using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public string[] NameBoad;
    public Text[] NameTextBoad;
    public string[] TimeBoad;
    public Text[] TimeTextBoad;
    public string[] DayTimeBoad;
    public Text[] DayTimeTextBoad;
    public AudioSource audiosource;
    public AudioClip cansel;

    // Start is called before the first frame update
    void Start()
    {
        for(int a = 0; a < NameBoad.Length; a++)//名前をロード
        {
            NameBoad[a] = PlayerPrefs.GetString("BoadName" + a);
            NameTextBoad[a].text = NameBoad[a];
            Debug.Log(a + "番目の名前を取得");
        }
        for(int b = 0; b < TimeBoad.Length; b++)//タイムをロード
        {
            TimeBoad[b] = PlayerPrefs.GetString("BoadTime" + b);
            TimeTextBoad[b].text = TimeBoad[b];
            Debug.Log(b + "番目のタイムを取得");
        }
        for (int c = 0; c < DayTimeBoad.Length; c++)//日時をロード
        {
            DayTimeBoad[c] = PlayerPrefs.GetString("BoadDayTime" + c);
            DayTimeTextBoad[c].text = DayTimeBoad[c];
            Debug.Log(c + "番目の日時を取得");
        }

        FadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBack()
    {
        audiosource.PlayOneShot(cansel);
        FadeManager.FadeOut(0);
    }
}
