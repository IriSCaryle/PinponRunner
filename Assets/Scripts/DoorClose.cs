using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{

    private bool isClose;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isClose == false)
        {
            Debug.Log("Playerが家に入りました");
           
            
            Debug.Log("ドアが閉まります");
            animator.SetBool("isOpen", !animator.GetBool("isOpen"));
            isClose = true;
        }
    }
}


