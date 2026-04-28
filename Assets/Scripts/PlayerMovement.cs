using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NoiseEmitter))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 6f;
    public float crouchSpeed = 2f;
    public bool canMove = true;

    [Header("Jump")]
    public float jumpHeight = 1.2f; // ~1 meter jump
    public float gravity = -20f;

    CharacterController controller;
    NoiseEmitter noise;

    Vector3 velocity;
    bool isCrouching;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        noise = GetComponent<NoiseEmitter>();
    }


    void Update()
    {

        if (canMove == true)
        {

            bool isGrounded = controller.isGrounded;

            // Ground stick force
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Determine speed
            float speed = isCrouching
                ? crouchSpeed
                : Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

            float x = Input.GetAxis("Horizontal");
            Vector3 move = Vector3.right * x;

            controller.Move(move * speed * Time.deltaTime);

            // Emit movement noise
            if (isGrounded && Mathf.Abs(x) > 0.1f)
            {
                if (isCrouching)
                    noise.Emit(noise.crouchNoise);
                else if (Input.GetKey(KeyCode.LeftShift))
                    noise.Emit(noise.sprintNoise);
                else
                    noise.Emit(noise.walkNoise);
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                noise.Emit(noise.jumpNoise);
            }

            // Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // Crouch toggle
            if (Input.GetKeyDown(KeyCode.C))
            {
                isCrouching = !isCrouching;
                controller.height = isCrouching ? 1f : 2f;
            }

        }
        
    }
    public bool IsCrouching() => isCrouching;
}