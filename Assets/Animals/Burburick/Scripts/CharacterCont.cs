using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCont : MonoBehaviour
{
    [Header("Aim")]

    [SerializeField] private Transform aimedTransform;
    float forwardAmount;
    float turnAmount;
    Transform cam;
    Vector3 camForward;
    Vector3 move;
    Vector3 moveInput;

    [Header("Animation")]

    Rigidbody rigidBody;
    public float speed = 1.2f;
    Vector3 lookPos;
    Animator anim;
    

    [Header("Gizmos")]

    
    [SerializeField] private  GameObject cursor;

    void Start()
    {
        anim = GetComponent<Animator>();
        SetupAnimator();
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) anim.SetBool("Hit", true);
        else anim.SetBool("Hit", false);
        Aiming();
    }
   
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(cam != null)
        {
            camForward = Vector3.Scale(cam.up, new Vector3(1, 0, 1)).normalized;
            move = vertical * camForward + horizontal * cam.right;
        }
        else
        {
            move = vertical * Vector3.forward + horizontal * Vector3.right;
        }
        if(move.magnitude > 1)
        {
            move.Normalize();
        }

        Move(move);
        Vector3 movement = new Vector3(horizontal, 0, vertical);
            rigidBody.angularVelocity = Vector3.zero;
    }

    private void Aiming()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200))
        {
            lookPos = hit.point;
        }
        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;
        var cursorPosition = hit.point;
        transform.LookAt(transform.position + lookDir, Vector3.up);
        cursor.transform.position = cursorPosition + new Vector3(0, 0.5f, 0);
        
    }
    void Move(Vector3 move)
    {
        if(move.magnitude > 1)
        {
            move.Normalize();
        }
        this.moveInput = move;
        ConvertMoveInput();
        UpdateAnimator();
    }
    void ConvertMoveInput() 
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;
    }
    void UpdateAnimator() 
    {
        anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    void SetupAnimator()
    {
        anim = GetComponent<Animator>();
        foreach (var childAnimator in GetComponentsInChildren<Animator>())
        {
            if(childAnimator != anim)
            {
                anim.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }
   
    //private void GizmoSettings()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        gizmo_target = !gizmo_target;
    //    }
    //}
}
