using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transtion : MonoBehaviour
{
    public Animator animator;
    public int trans;
     public Player player;

    private void Start()
    {
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        Animator animator = GetComponent<Animator>();

        this.gameObject.GetComponent<Player>();
        //あらかじめ設定していたintパラメーター「trans」の値を取り出す.
         trans = animator.GetInteger("trans");
        Debug.Log(trans);



    }


    void Update()
    {
       
        
        if (player.walk == true)//歩くモーションにする
        {
            trans = 2;
            //intパラメーターの値を設定する.
            animator.SetInteger("trans",trans);
        }
        if (player.run == true)//走るモーションにする
        {
            trans = 3;
            //intパラメーターの値を設定する.
            animator.SetInteger("trans", trans);
        }
            if (player.walk == false && player.run == false)//走っても歩いてもいないときは止まる
        {
            trans = 1;
            //intパラメーターの値を設定する.
            animator.SetInteger("trans",trans);
        }

        Debug.Log(trans);
    }
}
