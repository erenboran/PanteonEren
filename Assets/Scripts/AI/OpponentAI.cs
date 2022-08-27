using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentAI : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent agent;
    Animator oppAnim;
    Rigidbody m_Rigidbody;
    void Start()    
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        oppAnim = GetComponent<Animator>();
        agent.isStopped = true;

        GetComponent<NavMeshAgent>().speed = Random.Range(1f, 1.2f);

    }

    void Update()
    {
        agent.SetDestination(target.position);
        if (Input.GetButton("Fire1"))
        {            
            {
                agent.isStopped = false;
                oppAnim.SetBool("run", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))

        {
            transform.position = new Vector3(14f, 14f, 14f);
            agent.ResetPath();

        }
        if (collision.gameObject.CompareTag("Stick"))

        {
            GetComponent<NavMeshAgent>().speed = Random.Range(1.1f, 1.1f);
            agent.ResetPath();

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("finish"))
        {
            agent.velocity = Vector3.zero;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            oppAnim.SetBool("run", false);
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;

        }
    }
}
