using UnityEngine;

public class LookoutEnemy : MonoBehaviour
{
    public float baseFlipTime = 3f;

    EnemyDetection detection;

    float timer;

    void Start()
    {
        detection = GetComponent<EnemyDetection>();
        timer = baseFlipTime;
    }

    void Update()
    {
        if (detection == null) return;

        //Faster flipping at higher alert
        float modifier = 1f - (detection.alertLevel * 0.2f);
        float currentTime = Mathf.Max(0.8f, baseFlipTime * modifier);

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Flip();
            timer = currentTime;
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180f, 0);
    }
}

