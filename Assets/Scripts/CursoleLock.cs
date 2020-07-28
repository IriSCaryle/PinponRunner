using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoleLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //カーソルをロックして非表示にする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
