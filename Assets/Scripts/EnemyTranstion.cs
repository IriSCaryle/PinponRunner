using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTranstion : MonoBehaviour
{
    public Animator animator;
    public int trans;
    public Patrol patrolSC;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        patrolSC = enemy.GetComponent<Patrol>();

        trans = animator.GetInteger("trans");

    }

    // Update is called once per frame
    void Update()
    {
      if(patrolSC.distance < patrolSC.quitRange)//追跡されてると走る
        {
            trans = 2;

            animator.SetInteger("trans",trans);
        }

      if(patrolSC.distance > patrolSC.quitRange)
        {
            trans = 1;
            animator.SetInteger("trans", trans);

        }
    }
}
