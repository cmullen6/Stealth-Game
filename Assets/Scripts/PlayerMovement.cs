using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float crouchSpeed = 2f;
    public float jumpForce = 6f;
    public float gravity = -20f;

    CharacterController controller;
    Vector3 velocity;
    bool isCrouching;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float speed = isCrouching ? crouchSpeed :
                      Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        float x = Input.GetAxis("Horizontal");
        controller.Move(Vector3.right * x * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            velocity.y = jumpForce;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            controller.height = isCrouching ? 1f : 2f;
        }
    }

    public bool IsCrouching() => isCrouching;
}
