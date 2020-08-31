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
    public float staminaconsumption= 0.5f;//スタミナ消費量
    public float staminaheal = 0.6f;//スタミナ回復量
    public bool tentionmax;
    public Tension TentionScript;
    public int HiTentionMode;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        staminaDown();//通常のスタミナ消費
        staminamax();//テンションゲージを消費するとスタミナが減らなくなる
        tentionconsum();//テンションゲージが溜まりTを押すと判定がtrueになり他のスクリプトが動く5秒後falseになり制御終了
        //Debug.Log(tentionmax);
    }

    void staminamax()
    {
        if (tentionmax == true) {//テンションゲージを消費するとスタミナが100固定になりfillamountに常に送られる
            Staminacurrent = 100;
            image.fillAmount = Staminacurrent / maxStamina;
            }
    }

    void tentionconsum()
    {
        if (TentionScript.tempcount >= 30)//テンションの数値が30以上になった時
        {
            if (Input.GetKeyDown(KeyCode.T))//Tが押されたら
            {


                tentionmax = true; //テンションを消費する(この条件でif文を書くとそれが動く)

                Invoke("TentionNomal", HiTentionMode);//５秒後にTentionNomalを実行する↓↓
            }
        }
    }
    
    void TentionNomal()
    {

        tentionmax = false;//テンションゲージの消費のオンをオフにして元に戻す
    }
    void staminaDown()
    {
        //スタミナが0以上で走ってる間スタミナゲージを減らす
        if (0 <= Staminacurrent && playerscript.run == true && tentionmax == false) 
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
            playerscript.DashSpeed = 0.75f;



        }
        else
        {
            playerscript.DashSpeed = 2;
        }


    }


   
}
