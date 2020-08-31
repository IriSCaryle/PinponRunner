using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FadeManager.FadeIn();




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeManager.FadeOut(0);
        }
    }
}
