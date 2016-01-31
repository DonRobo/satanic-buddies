using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    enum AnimationState
    {
        IDLE = 0,
        WALK = 1
    }

    public Image healthbar;

    public float maxHealth = 200;
    private float health;
    public float walkSpeed = 300.0f;

    public float animationSpeedFactor = 0.1f;

    public float zMovementAnimationSpeedFactor = 0.5f;

    // Maximum Z deviation that the player can have
    public float worldZLimit = 1.0f;

    public float gravity = 0.0001F;

    public Vector3 aimDirection;

    public GameObject projectilePrefab;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 initialPosition;
    private CharacterController characterController;
    private Animator animator;
    private GameObject spriteView;
    private AnimationState currentAnimationState = AnimationState.IDLE;
    private const float EPSILON = 0.001f;

    void Start()
    {
        initialPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        spriteView = transform.FindChild("PlayerSpriteView").gameObject;
        health = maxHealth;
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

        if (Mathf.Abs(moveDirection.x) > EPSILON || Mathf.Abs(moveDirection.z) > EPSILON)
        {
            setState(AnimationState.WALK);
        }
        else
        {
            animator.speed = 100;
            setState(AnimationState.IDLE);
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

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > EPSILON || Mathf.Abs(Input.GetAxis("Vertical")) > EPSILON)
        {
            aimDirection = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;
        }

        if (Input.GetButtonDown("PlayerFire"))
        {
            GameObject proj = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            proj.GetComponent<Projectile>().direction = aimDirection;
        }
    }

    private void setState(AnimationState state)
    {
        if (this.currentAnimationState == state)
            return;

        //Debug.Log("Setting state to " + state.ToString());
        animator.SetInteger("state", (int)state);
        currentAnimationState = state;

    }

    public void Damage(float damage)
    {
        health -= damage;
        healthbar.rectTransform.anchorMax = new Vector2(health / maxHealth, 1);
        if (health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
