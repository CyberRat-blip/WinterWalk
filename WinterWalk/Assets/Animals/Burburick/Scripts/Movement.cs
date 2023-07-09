using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 2f;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 directionVector = new Vector3(h, 0f, v);

        if (directionVector.magnitude > Mathf.Abs(0.03f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 10);
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        //animator.SetFloat("speed", Vector3.Lerp(A, B, progress));
        // anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, 1) * speed;
        rigidbody.velocity = new Vector3(moveDir.x,rigidbody.velocity.y,moveDir.z);

        //rigidbody.angularVelocity = Vector3.zero;
        


    }
    
}