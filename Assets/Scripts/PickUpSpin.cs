using UnityEngine;

/// <summary>
/// Makes the GameObject move up and down in a smooth bobbing motion.
/// Attach this script to your collectible object.
/// </summary>
public class BobbingCollectible : MonoBehaviour
{
    [Header("Bobbing Settings")]
    [Tooltip("How high the object moves from its starting position.")]
    public float bobHeight = 0.25f;

    [Tooltip("How fast the object moves up and down.")]
    public float bobSpeed = 2f;

    // Internal variables
    private Vector3 startPos;

    void Start()
    {
        // Store the initial position
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate new Y position using sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        // Apply bobbing motion
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}