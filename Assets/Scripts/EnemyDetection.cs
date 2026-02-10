using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float visionRange = 8f;
    public float visionAngle = 45f;
    public Transform visionOrigin;
    public LayerMask visionMask;
    public EnemyTuningProfile tuning;


    public float noiseSensitivity = 1f;

    [Range(0, 2)] public int alertLevel;
    public float detectionValue;

    public float detectionFillSpeed = 1f;
    public float detectionDecaySpeed = 0.5f;

    Transform player;
    NoiseEmitter playerNoise;

    public System.Action<int> OnAlertLevelChanged;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerNoise = player.GetComponent<NoiseEmitter>();
    }

    void Update()
    {
        HandleVision();
        HandleNoise();

        detectionValue = Mathf.Clamp01(detectionValue);

        int newLevel =
            detectionValue >= 0.66f ? 2 :
            detectionValue >= 0.33f ? 1 : 0;

        if (newLevel != alertLevel)
        {
            alertLevel = newLevel;
            OnAlertLevelChanged?.Invoke(alertLevel);
        }
    }

    void HandleVision()
    {
        Vector3 dir = (player.position - visionOrigin.position).normalized;
        if (Vector3.Angle(visionOrigin.forward, dir) > visionAngle) return;

        if (Physics.Raycast(visionOrigin.position, dir, out RaycastHit hit, visionRange, visionMask))
        {
            if (hit.transform.CompareTag("Player"))
                detectionValue += detectionFillSpeed * Time.deltaTime;
        }
        else
            detectionValue -= detectionDecaySpeed * Time.deltaTime;
    }

    void HandleNoise()
    {
        float noise = playerNoise.GetRadius();
        if (noise <= 0) return;

        if (Vector3.Distance(transform.position, player.position) < noise)
            detectionValue += noiseSensitivity * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        if (!visionOrigin) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 left = Quaternion.Euler(0, -visionAngle, 0) * visionOrigin.forward;
        Vector3 right = Quaternion.Euler(0, visionAngle, 0) * visionOrigin.forward;

        Gizmos.DrawRay(visionOrigin.position, left * visionRange);
        Gizmos.DrawRay(visionOrigin.position, right * visionRange);
    }


}
