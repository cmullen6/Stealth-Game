using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyTuningProfile tuning;
    public Transform visionOrigin;
    public LayerMask visionMask;

    [Header("Runtime")]
    [Range(0, 3)] public int alertLevel;
    public float detectionValue;

    Transform player;
    NoiseEmitter playerNoise;

    public System.Action<int> OnAlertLevelChanged;

    void Start()
    {
        if (!visionOrigin)
            Debug.LogError("Vision Origin missing on " + name);

        if (!tuning)
            Debug.LogError("Tuning missing on " + name);

        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("No Player found in scene!");
            return;
        }

        player = playerObj.transform;
        playerNoise = player.GetComponent<NoiseEmitter>();
    }

    void Update()
    {
        if (player == null || tuning == null || visionOrigin == null) return;

        HandleVision();
        HandleNoise();

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
                GameManager.Instance.TriggerGameOver();
            }
        }
    }

    void HandleVision()
    {

        if (ShadowZone.PlayerInShadow())
        {
            detectionValue -= tuning.detectionDecaySpeed * Time.deltaTime;
            return;
        }

        Vector3 dir = (player.position - visionOrigin.position).normalized;

        if (Vector3.Angle(visionOrigin.forward, dir) > tuning.visionAngle)
        {
            detectionValue -= tuning.detectionDecaySpeed * Time.deltaTime;
            return;
        }

        if (Physics.Raycast(visionOrigin.position, dir, out RaycastHit hit, tuning.visionRange, visionMask))
        {
            if (hit.transform.CompareTag("Player"))
            {
                float multiplier =
                    alertLevel == 0 ? 1f :
                    alertLevel == 1 ? 1.5f :
                    alertLevel == 2 ? 2.5f : 3.5f;

                detectionValue += tuning.detectionFillSpeed * multiplier * Time.deltaTime;
            }
        }
        else
        {
            detectionValue -= tuning.detectionDecaySpeed * Time.deltaTime;
        }
    }

    void HandleNoise()
    {
        if (playerNoise == null) return;

        float noise = playerNoise.GetRadius();
        if (noise <= 0) return;

        if (Vector3.Distance(transform.position, player.position) < noise)
        {
            detectionValue += tuning.noiseSensitivity * Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        if (!visionOrigin || tuning == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tuning.visionRange);

        Vector3 left = Quaternion.Euler(0, -tuning.visionAngle, 0) * visionOrigin.forward;
        Vector3 right = Quaternion.Euler(0, tuning.visionAngle, 0) * visionOrigin.forward;

        Gizmos.DrawRay(visionOrigin.position, left * tuning.visionRange);
        Gizmos.DrawRay(visionOrigin.position, right * tuning.visionRange);
    }
}