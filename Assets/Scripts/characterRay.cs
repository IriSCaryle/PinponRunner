using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRay : MonoBehaviour
{

    public bool Item;
    float distance = 5.6f;
    // Start is called before the first frame update
    void Start()
    {
        Item = false;

    }

    // Update is called once per frame
    void Update()
    {//ゲーム画面の中央に固定したマウスカーソルからRayを発射する
        Ray ChrRay = new Ray(transform.position + new Vector3(0, 0, 7), transform.forward); 
        //Debug.DrawLine(ChrRay.origin, ChrRay.direction , Color.red,distance);
        
        //            rayの原点         rayの方向        色          ?
        // Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 15.6f);
        RaycastHit hit;
        if (Physics.Raycast(ChrRay, out hit, distance))
        {
            if (hit.collider.gameObject.tag == "Item")
            {
                Item = true;
            }
            else
            {
                Item = false;
            }
        
      
        }


        Debug.Log(Item);
    }


}

