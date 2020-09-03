using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntiManager : MonoBehaviour
{
    bool isFirstBoot= true;
    public int[] intiTimeboadint = new int[10];
    // Start is called before the first frame update
    void Start()
    {
        if (isFirstBoot)
        {
            for (int i = 0; i <= intiTimeboadint.Length; i++) {
                PlayerPrefs.SetInt("Boadint" + i, intiTimeboadint[i]);
                
                    }
            Debug.Log("TimeBoad初期化完了");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
