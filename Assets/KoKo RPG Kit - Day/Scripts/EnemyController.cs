using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;
    public delegate void EnemyKilled();
    //public static event EnemyKilled OnEnemyKilled;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    private Animator eAnimator;
    //private Animator enemy;

    private bool eRunning = false;

    //private bool eAttack = false;

    private bool eIdle = false;

    float eAttack;
    public float attackRadius = 2f;
    


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        eAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            eRunning = false;
        }
        else
        {
            eRunning = true;
        }
        eAnimator.SetBool("running", eRunning);
        /*
        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            eAttack = false;
        }
        else
        {
            eAttack = true;
            
        }
        eAnimator.SetBool("attacking", eAttack);
        */
        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            eIdle = false;
        }
        else
        {
            eIdle = true;
        }
        eAnimator.SetBool("idle", eIdle);

        if (distance <= attackRadius)
        {
            //agent.SetDestination(target.position);
            eAnimator.SetFloat("attacking", eAttack);
         
        }
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
