using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_To_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;

    private bool mRunning = false;

     UnityEngine.AI.NavMeshAgent agent;

    public GameObject click;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);

            }                    
            Instantiate(click, hit.point, Quaternion.identity);
            
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }
        mAnimator.SetBool("running", mRunning);

    }

}
