using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{

    public bool Item;
    // Start is called before the first frame update
    void Start()
    {
        Item = false;
    }

    // Update is called once per frame
    void Update()
    {//ゲーム画面の中央に固定したマウスカーソルからRayを発射する
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 15.6f);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, 15.6f))
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
        else
        {
            Item = false;
        }


        Debug.Log(Item);
    }


}

