using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisturbance : MonoBehaviour
{

    BoxCollider wallcollider;
    // Start is called before the first frame update
    void Start()
    {
        wallcollider = this.GetComponent<BoxCollider>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            wallcollider.isTrigger = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
           
                wallcollider.isTrigger = false;
            
        }
    }
}
