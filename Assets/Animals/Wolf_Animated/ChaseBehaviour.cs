using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    private Transform agentTransform;
    private NavMeshAgent agent;
    private Transform target;
    private float chaseRange = 700f;
    private float attackRange = 3f;
    private float patrolRange = 700f;
    private float updatePathInterval = 1f;
    private float elapsedTime = 0f;
    private float sqrChaseRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agentTransform = animator.transform;
        agent = agentTransform.GetComponent<NavMeshAgent>();
        target = FindObjectOfType<TargetPositionProvider>().transform;

        elapsedTime = 0f;
        agent.SetDestination(target.position);

        sqrChaseRange = chaseRange * chaseRange;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updatePathInterval)
        {
            agent.SetDestination(target.position);
            elapsedTime = 0f;
        }

        if ((agentTransform.position - target.position).sqrMagnitude > sqrChaseRange)
        {
            animator.SetBool("isChasing", false);
        }
        else
        {
            float distance = Vector3.Distance(agentTransform.position, target.position);
            if (distance <= attackRange)
            {
                animator.SetBool("isAttacking", true);
                Vector3 directionToTarget = target.position - agentTransform.position;
                Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
                agentTransform.rotation = Quaternion.Slerp(agentTransform.rotation, lookRotation, Time.deltaTime * 5f);
            }
            else if (distance > patrolRange)
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isPatrolling", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.ResetPath();
    }
}