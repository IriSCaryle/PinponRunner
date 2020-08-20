using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemyController : MonoBehaviour
{

    protected float defaultMoveSpeed;

    protected Rigidbody rigidBody;
    protected GameSystem gameManager;
    protected NavMeshAgent agent;
    protected Transform target;
    protected Animator animator;

    public float MoveSpeed { set; get; }

    protected virtual void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSystem>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        defaultMoveSpeed = agent.speed;
        MoveSpeed = defaultMoveSpeed;
    }


    protected virtual void Update()
    {
        if (!gameManager.countDown)
        {
            Stop();

            return;
        }

        if (target != null)
        {
            agent.speed = MoveSpeed;

            Move();
        }
        else
        {
            Stop();
        }
    }

    protected virtual void Move()
    {
        animator.SetFloat("MoveSpeed", agent.speed, 0.1f, Time.deltaTime);


    }

    protected virtual void Stop()
    {
        agent.speed = 0;

        animator.SetFloat("MoveSpeed", agent.speed, 0.1f, Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
  //          gameManager.GameOver();
        }
    }

    protected void ResetMoveSpeed()
    {
        MoveSpeed = defaultMoveSpeed;
    }
}