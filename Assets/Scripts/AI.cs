using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PatrolOptions // your custom enumeration
{
    noPatrol,
    patrolPoints,
    patrolRandom
};

public class AI : MonoBehaviour
{
    NavMeshAgent nav;

    public PatrolOptions patrolType;

    public List<Transform> patrolPoints;
    public float pointTriggerDistance = 1;
    public float patrolRandomDistance = 1f;

    int currentPatrolPoint = 0;

    public Transform chaseTarget;
    public float chaseRadius = 8;

    bool isPatrolling = false;
    bool isChasing = false;
   

    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();

        StartPatrol();
    }

    void StartPatrol()
    {
        if (patrolType == PatrolOptions.patrolPoints)
        {
            if (patrolPoints.Count == 0)
            {
                Debug.LogError("No patrol points to follow!");
            }
            else
            {
                isPatrolling = true;
                StartCoroutine(PatrolPointRoutine());
            }
        }
        else if (patrolType == PatrolOptions.patrolRandom)
        {
            if (patrolPoints.Count != 1)
            {
                Debug.LogError("No one single patrol point to move around!");
            }
            else
            {
                isPatrolling = true;
                StartCoroutine(PatrolRandomRoutine());
            }
        }

        if (chaseTarget != null)
        {
            StartCoroutine(SearchRoutine());
        }
    }

    IEnumerator PatrolPointRoutine()
    {
        while (isPatrolling)
        {
            if (Vector3.Distance(transform.position, nav.destination) <= pointTriggerDistance)
            {
                currentPatrolPoint += 1;
                if (currentPatrolPoint == patrolPoints.Count)
                    currentPatrolPoint = 0;

                nav.SetDestination(patrolPoints[currentPatrolPoint].position);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator PatrolRandomRoutine()
    {
        nav.SetDestination(patrolPoints[0].position);
        while (isPatrolling)
        {
            if (Vector3.Distance(transform.position, nav.destination) <= pointTriggerDistance)
            {
                Vector3 randomDirection = Random.insideUnitSphere * patrolRandomDistance;
                randomDirection += patrolPoints[0].position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, patrolRandomDistance, 1);
                Vector3 finalPosition = hit.position;

                nav.SetDestination(finalPosition);
            }

                yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator SearchRoutine()
    {
        while (!isChasing)
        {
            if (Vector3.Distance(transform.position, chaseTarget.position) <= chaseRadius)
            {
                isChasing = true;
                isPatrolling = false;
                StartCoroutine(ChaseRoutine());
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ChaseRoutine()
    {
        while (isChasing)
        {
            nav.SetDestination(chaseTarget.position);

            yield return new WaitForFixedUpdate();
        }
    }
}
