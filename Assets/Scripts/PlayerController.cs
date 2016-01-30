using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    enum AnimationState
    {
        IDLE = 0,
        WALK
    }

    public float walkSpeed = 300.0f;

    public float animationSpeedFactor = 30.0f;

    public float zMovementAnimationSpeedFactor = 0.5f;

    // Maximum Z deviation that the player can have
    public float worldZLimit = 1.0f;

    public float gravity = 0.0001F;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 initialPosition;
    private CharacterController characterController;
    private Animator animator;
    private GameObject spriteView;
    public Vector3 aimDirection;

    void Start()
    {
        initialPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        spriteView = transform.FindChild("PlayerSpriteView").gameObject;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            float translationX = Input.GetAxis("Horizontal") * walkSpeed;
            float translationZ = Input.GetAxis("Vertical") * walkSpeed;

            translationZ = Mathf.Clamp(transform.position.z + translationZ,
                initialPosition.z - worldZLimit, initialPosition.z + worldZLimit);

            moveDirection = new Vector3(translationX, 0, translationZ - transform.position.z);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        animator.speed = (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z) * zMovementAnimationSpeedFactor) * animationSpeedFactor;

        moveDirection.y -= gravity;

        if (Mathf.Abs(moveDirection.x) > 0 || Mathf.Abs(moveDirection.z) > 0)
        {
            animator.SetInteger("state", (int)AnimationState.WALK);
        }
        else
        {
            animator.SetInteger("state", (int)AnimationState.IDLE);
        }
        if (moveDirection.x < 0 && spriteView.transform.localScale.x > 0)
        {
            spriteView.transform.localScale = new Vector3(-spriteView.transform.localScale.x, spriteView.transform.localScale.y, spriteView.transform.localScale.z);
        }
        else if (moveDirection.x > 0 && spriteView.transform.localScale.x < 0)
        {
            spriteView.transform.localScale = new Vector3(-spriteView.transform.localScale.x, spriteView.transform.localScale.y, spriteView.transform.localScale.z);
        }

        characterController.Move(moveDirection);

        aimDirection = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;
    }
}
