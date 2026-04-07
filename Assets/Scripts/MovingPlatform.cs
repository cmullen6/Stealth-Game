using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveHeight = 3f;     // How high it moves
    public float speed = 2f;          // Movement speed
    public float pauseTime = 1.5f;    // Pause duration at top & bottom

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool goingUp = true;
    private bool isPaused = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveHeight;
        StartCoroutine(MovePlatform());
    }

    System.Collections.IEnumerator MovePlatform()
    {
        while (true)
        {
            if (!isPaused)
            {
                Vector3 destination = goingUp ? targetPos : startPos;

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    destination,
                    speed * Time.deltaTime
                );

                // Check if reached destination
                if (Vector3.Distance(transform.position, destination) < 0.01f)
                {
                    isPaused = true;
                    yield return new WaitForSeconds(pauseTime);

                    goingUp = !goingUp;
                    isPaused = false;
                }
            }

            yield return null;
        }
    }
}

