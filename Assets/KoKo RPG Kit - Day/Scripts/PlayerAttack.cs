using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject selectedUnit;
    Transform target;

    UnityEngine.AI.NavMeshAgent agent;

    public float attackRadius = 2f;
    float pAttack;

    private Animator pAnimator;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        pAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SelectTarget();
            //FaceTarget();
        }
        
        float distance = Vector3.Distance(target.position, transform.position);
        /*
        if (distance <= attackRadius)
        {
            pAnimator.SetFloat("attacking", pAttack);
        }
        */
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            pAnimator.SetTrigger("Attack");
        }
    }
    
    void SelectTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 10000))
        {
            if(hit.transform.tag == "Enemy")
            {
                selectedUnit = hit.transform.gameObject;
                agent.SetDestination(hit.point);
                transform.LookAt(hit.point);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
