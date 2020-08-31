using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tension : MonoBehaviour
{

    public bool tentiondown;
    public Player playerscript;//プレイヤースクリプト
    public Image tentionimage;
    public float Tentioncurrent;
    public int maxTention;
    public Stamina staminascript;
    
    public int tempcount =0;
    int tentionmaxtime = 5;


    // Start is called before the first frame update
    void Start()
    {
        tentionimage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            Tention();
       
        TentionReset();
        TentionReset2();
        
    }
    void Tention()
    {

        if (tempcount != playerscript.pinpontotal && staminascript.tentionmax == false )
        {
            Tentioncurrent += (playerscript.pinpontotal ) - tempcount;
            tempcount = (int)Tentioncurrent;

            tentionimage.fillAmount = Tentioncurrent / maxTention;
        }
    }

    void TentionReset()
    {
        if (staminascript.tentionmax == true)
        {
            Tentioncurrent = 0;
            tempcount = 0;
            playerscript.pinpontotal = 0;
            tentionimage.fillAmount = Tentioncurrent / maxTention;
        }
    }
    public void TentionReset2()
    {if (tentiondown == true)
        {
            Debug.Log("テンションダウン");
            Tentioncurrent = 0;
            tempcount = 0;
            playerscript.pinpontotal = 0;
            tentionimage.fillAmount = Tentioncurrent / maxTention;
            tentiondown = false;
        }
    }


}
