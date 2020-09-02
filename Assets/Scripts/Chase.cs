using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public AudioSource audiosource;
    public AudioClip running;
    public AudioClip walking;

    void Start()
    {
      
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
            agent.destination = target.transform.position; //navMeshAgentの操作
        
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("つかまりー");
        }
    }

    public void Walksound()
    {
        audiosource.PlayOneShot(walking);
    }
    public void Rundound()
    {
        audiosource.PlayOneShot(running);
    }
}