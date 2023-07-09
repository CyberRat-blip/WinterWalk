using UnityEngine;
using UnityEngine.AI;

public class TargetPositionProvider : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform targetTransform = target;
        animator.SetTrigger("UpdateTarget");
        animator.transform.position = targetTransform.position;
    }
}