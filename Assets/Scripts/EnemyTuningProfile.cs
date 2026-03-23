using UnityEngine;

[CreateAssetMenu(menuName = "Stealth/Enemy Tuning")]
public class EnemyTuningProfile : ScriptableObject
{
    [Header("Vision")]
    public float visionRange = 8f;
    public float visionAngle = 45f;

    [Header("Detection")]
    public float detectionFillSpeed = 1f;
    public float detectionDecaySpeed = 0.5f;
    public float noiseSensitivity = 1f;

    [Header("Movement")]
    public float baseSpeed = 2f;
    public float chaseSpeed = 5f;
    public float turnSpeed = 90f;
}