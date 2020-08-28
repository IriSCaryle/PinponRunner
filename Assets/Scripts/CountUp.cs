using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUp : MonoBehaviour
{
    public Text CountUpText;

    public float secondTime;

    public string DecimalTime;
    public int minute;

    public GameSystem gameManager;
    public string TotalTime;


    // Start is called before the first frame update
    void Start()
    {
       secondTime = 0;
        DecimalTime = "000";
        minute = 00;


    }

    // Update is called once per frame
    void Update()
    {


        //　制限時間が0秒以下、countDownがfalseなら何もしない
        if (!gameManager.countDown)
        {
            return;
        }


        secondTime += Time.deltaTime;


        
        if(secondTime >= 60)
        {
            secondTime = 0;
            minute += 1;
        }

        CountUpText.text = minute + "\'" + secondTime.ToString("0#.###");

        if (gameManager.countdown == false){

            TotalTime = CountUpText.text;
            Debug.Log(TotalTime);
        }
        
    }


    
}
