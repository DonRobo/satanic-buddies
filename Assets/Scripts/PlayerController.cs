using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 300.0f;

    // Maximum Z deviation that the player can have
    public float worldZLimit = 1.0f;

    public float gravity = 0.0001F;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 initialPosition;
    private CharacterController controller;

    void Start ()
    {
        initialPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }
	
	void Update ()
    {
        if (controller.isGrounded)
        {
            
            float translationZ = Input.GetAxis("Vertical") * walkSpeed;
            float translationX = Input.GetAxis("Horizontal") * walkSpeed;

            float newZ = transform.position.z + translationZ;

            newZ = Mathf.Clamp(newZ, initialPosition.z - worldZLimit, initialPosition.z + worldZLimit);

            moveDirection = new Vector3(translationX, 0, newZ - transform.position.z);
            moveDirection = transform.TransformDirection(moveDirection);
      
           if (Input.GetButton("Jump"))
               moveDirection.y = 6.0f;

        }
        moveDirection.y -= gravity;
        controller.Move(moveDirection);
    }
}
