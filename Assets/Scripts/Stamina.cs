using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{

    public Player playerscript;//プレイヤーのスクリプト
    public Image image;//Imageコンポーネント
    public float Staminacurrent = 100.0f;//現在のスタミナ
    public int maxStamina = 100;//最大スタミナ量
    public float staminaconsumption= 1.3f;//スタミナ消費量
    public float staminaheal = 0.6f;//スタミナ回復量
   


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        staminaDown();
    }

    void staminaDown()
    {
        //スタミナが0以上で走ってる間スタミナゲージを減らす
        if (0 <= Staminacurrent && playerscript.run == true) 
        {
            Staminacurrent = Staminacurrent - staminaconsumption;

            image.fillAmount = Staminacurrent / maxStamina;

        }

        //スタミナが100以下で走っていない間スタミナゲージを減らす
        if (100 >= Staminacurrent && playerscript.run == false)
        {
                
                    
                    Staminacurrent = Staminacurrent + staminaheal;

                    image.fillAmount = Staminacurrent / maxStamina;
            

        }
        
        if(Staminacurrent <= 0 )
        {
            playerscript.DashSpeed = 1;



        }
        else
        {
            playerscript.DashSpeed = 2;
        }


    }


   
}
