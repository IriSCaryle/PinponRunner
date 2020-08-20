using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{

    //public
    public float speed = 1.0f;
    public Tension TentionScript; 

    //private
    private Text text;
    private Image image;
    private float time;


    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.IMAGE;

    void Start()
    {
        
        //アタッチしてるオブジェクトを判別
        
        
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();

        image.color = new Color(1, 1, 1, 0); //テンションゲージがたまったことを知らせる白い画像を透明に
        
        
    }

    void Update()
    {


        //テンションが100以上でテンションゲージを消費していない時は白い画像を表示する
        if(TentionScript.Tentioncurrent >= 100 && TentionScript.staminascript.tentionmax ==false)
        {
            image.color = new Color(1, 1, 1, 1);
            //オブジェクトのAlpha値を更新

            image.color = GetAlphaColor(image.color);

           
        }

        resettentionmax();
        
           
        
      
    }

    void resettentionmax()
    {
        //テンションゲージを消費して、テンションの一時変数が0の時、画像を非表示にする
        if (TentionScript.tempcount <=0 && TentionScript.staminascript.tentionmax == true)
        {
            
            
                image.color = new Color(1, 1, 1, 0);
            

        }
    }

    //Alpha値を更新してColorを返す 
    Color GetAlphaColor(Color color)
    {
       
            time += Time.deltaTime * 5.0f * speed;
            color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        
            return color;
        
    }
}
