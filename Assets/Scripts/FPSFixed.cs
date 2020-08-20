using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFixed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Application.targetFrameRate = 60; //60FPS固定
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
