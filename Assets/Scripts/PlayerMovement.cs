using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NoiseEmitter))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float crouchSpeed = 2f;
    public float jumpForce = 6f;
    public float gravity = -20f;

    CharacterController controller;
    NoiseEmitter noise;

    Vector3 velocity;
    bool isCrouching;
    bool isGroundedByWall;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        noise = GetComponent<NoiseEmitter>();
    }

    void Update()
    {
        float speed = isCrouching
            ? crouchSpeed
            : Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        float x = Input.GetAxis("Horizontal");
        Vector3 move = Vector3.right * x;

        controller.Move(move * speed * Time.deltaTime);

        // Movement noise
        if (isGroundedByWall && Mathf.Abs(x) > 0.1f)
        {
            if (isCrouching)
                noise.Emit(noise.crouchNoise);
            else if (Input.GetKey(KeyCode.LeftShift))
                noise.Emit(noise.sprintNoise);
            else
                noise.Emit(noise.walkNoise);
        }

        // Stick to wall/platform
        if (isGroundedByWall && velocity.y < 0)
            velocity.y = -5f;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGroundedByWall)
        {
            velocity.y = jumpForce;
            noise.Emit(noise.jumpNoise);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            controller.height = isCrouching ? 1f : 2f;
        }
    }

    void LateUpdate()
    {
        // Reset every frame — will be re-set if we hit a wall/platform
        isGroundedByWall = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Only count surfaces tagged as Wall AND hit from above-ish
        if (hit.collider.CompareTag("Wall") && hit.normal.y > 0.3f)
        {
            isGroundedByWall = true;
        }
    }

    public bool IsCrouching() => isCrouching;
}
