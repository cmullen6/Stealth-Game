using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Setup")]
    public EnemyTuningProfile tuning;
    public Transform visionOrigin;
    public LayerMask visionMask;

    [Header("Runtime")]
    [Range(0, 3)] public int alertLevel;
    public float detectionValue;

    Transform player;

    private Animator animator;

    public System.Action<int> OnAlertLevelChanged;

    void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
            player = p.transform;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null || tuning == null || visionOrigin == null) return;

        HandleVision();

        detectionValue = Mathf.Clamp01(detectionValue);

        int newLevel =
            detectionValue >= 1f ? 3 :
            detectionValue >= 0.66f ? 2 :
            detectionValue >= 0.33f ? 1 : 0;

        if (newLevel != alertLevel)
        {
            alertLevel = newLevel;
            OnAlertLevelChanged?.Invoke(alertLevel);

            if (alertLevel == 3)
            {

                animator.SetTrigger("Grab");

                GameManager.Instance.TriggerGameOver();

            }
        }
    }

    void HandleVision()
    {
        Vector3 dir = (player.position - visionOrigin.position).normalized;
        float angle = Vector3.Angle(visionOrigin.forward, dir);

        bool seesPlayer = false;

        if (angle <= tuning.visionAngle)
        {
            if (Physics.Raycast(
                visionOrigin.position,
                dir,
                out RaycastHit hit,
                tuning.visionRange,
                visionMask))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    seesPlayer = true;
                }
            }
        }

        if (seesPlayer)
        {
            // DETECTION SPEED
            float baseRate = 0.6f; // slower base

            float levelModifier =
                alertLevel == 0 ? 1f :
                alertLevel == 1 ? 0.9f :
                alertLevel == 2 ? 0.8f :
                0.7f;

            detectionValue += baseRate * levelModifier * Time.deltaTime;
        }
        else
        {
            // SLOWER DECAY (prevents flicker)
            detectionValue -= 0.25f * Time.deltaTime;
        }
    }
}