using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tension : MonoBehaviour
{


    public Player playerscript;//プレイヤースクリプト
    public Image tentionimage;
    public float Tentioncurrent;
    public int maxTention;
    
    int tempcount =0;


    // Start is called before the first frame update
    void Start()
    {
        tentionimage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            Tention();
        
    }
    void Tention()
    {

        if (tempcount != playerscript.pinpontotal  )
        {
            Tentioncurrent += (playerscript.pinpontotal ) - tempcount;
            tempcount = (int)Tentioncurrent;

            tentionimage.fillAmount = Tentioncurrent / maxTention;
        }
    }
}
