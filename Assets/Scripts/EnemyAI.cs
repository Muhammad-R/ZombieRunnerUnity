using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;
    
    
    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;

    public bool isProvoked = false;

    private EnemyHealth health;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }
    
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
        }
        CalculateDistanceAndMove();
    }

    private void CalculateDistanceAndMove()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            MoveToTarget();
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = where the target is, rotate at a certain speed
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
