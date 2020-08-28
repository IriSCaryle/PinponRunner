using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseSC : MonoBehaviour
{
    public GameObject gamemanager;
    public GameSystem gamesystem;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)//家のコライダーに入った時
    {
        if (other.CompareTag("Player") == true && gamesystem.Key == false)//踏んだコライダーのタグがPlayerタグだった場合
        {
            Debug.Log("鍵がないと家に入れません鍵を手に入れましょう");


        }else if(other.CompareTag("Player")== true && gamesystem.Key == true )
        {
            Debug.Log("家に入りますか？");


            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("家に入った");

                gamesystem.InHouse = true;
            }
        }
    }
}
