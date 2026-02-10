using UnityEngine;

[CreateAssetMenu(menuName = "Stealth/Enemy Tuning")]
public class EnemyTuningProfile : ScriptableObject
{
    public float visionRange = 8f;
    public float visionAngle = 45f;
    public float detectionFillSpeed = 1f;
    public float detectionDecaySpeed = 0.5f;

    public float baseSpeed = 2f;
    public float chaseSpeed = 5f;
    public float turnSpeed = 90f;
}
