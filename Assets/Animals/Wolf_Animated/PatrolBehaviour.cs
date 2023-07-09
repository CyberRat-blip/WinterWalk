using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 10;
    List<Node> path;
    Grid grid;

    void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
            points.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Очищаем путь, чтобы избежать пересечения с состоянием Chase
        path = null;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 20)
        {
            animator.SetBool("isPatrolling", false);
            timer = 0;
        }

        // Обновляем путь, если персонаж обнаружен поблизости
        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < chaseRange)
            {
                // Переключаемся в режим преследования
                animator.SetBool("isChasing", true);
                return;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}