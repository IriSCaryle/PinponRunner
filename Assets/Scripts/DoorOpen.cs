using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private bool isNear;
    private bool isOpen;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        isOpen = false;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isNear == true && isOpen == false)
        {
            Debug.Log("ドアが開きます");
            animator.SetBool("isOpen", !animator.GetBool("isOpen"));
            isOpen = true;
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOpen == false)
        {
            Debug.Log("Playerが判定圏内");
            Debug.Log("ドアを開けますか？");
            isNear = true;
            
        }
    }
}


