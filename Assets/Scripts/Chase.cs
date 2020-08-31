using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        agent.destination = target.transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("つかまりー");
        }
    }
}