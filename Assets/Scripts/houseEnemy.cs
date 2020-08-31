using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class houseEnemy : MonoBehaviour
{

    [SerializeField] BoxCollider housecollider;//家のコライダーを入れるやつ
    public GameObject Door;
    public Animator DoorAnimation;
    [SerializeField] Chase chasescript;
    int state;

    public Vector3 pos;
    public GameObject Target;

    public NavMeshAgent agent;
    public Player playersc;
    // Start is called before the first frame update
    void Start()
    {
        chasescript.enabled = false;
        DoorAnimation = Door.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (playersc.DestroyComp)
        {
            state = 1;
            DoorAnimation.SetInteger("state", state);

            if (state == 1)
            {

                while (Door.transform.position == this.transform.position)
                {
                    pos = Door.transform.position - this.transform.position;
                    this.transform.position += pos;
                }

                state = 3;
                DoorAnimation.SetInteger("state", state);
                Targetchase();
            }
        }
    }
    void Targetchase()
    {
        chasescript.enabled = true;
    }
}
