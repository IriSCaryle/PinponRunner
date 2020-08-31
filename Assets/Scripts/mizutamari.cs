using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mizutamari : MonoBehaviour
{
    public Tension tensionsc;
    
    public Collider MizutamaCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider other)
    {

       
        if (other.gameObject.CompareTag("Player")) {
            tensionsc.tentiondown = true;
            Debug.Log("プレイヤー");
        }
    }
  
}
