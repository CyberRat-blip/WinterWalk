using UnityEngine;

public class BaseCharacterMovement : MonoBehaviour
{
    
    public float movementSpeed = 3;
    protected Vector3 movementVector;
    protected void Update() => movementVector = transform.right  * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
}
