using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagFind : MonoBehaviour
{


    public GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    blocks = GameObject.FindGameObjectsWithTag("Target");
    }
}
