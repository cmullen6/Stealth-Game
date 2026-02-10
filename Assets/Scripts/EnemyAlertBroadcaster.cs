using UnityEngine;

public class EnemyAlertBroadcaster : MonoBehaviour
{
    public float alertRadius = 8f;

    EnemyDetection detection;

    void Awake()
    {
        detection = GetComponent<EnemyDetection>();
        detection.OnAlertLevelChanged += Broadcast;
    }

    void Broadcast(int level)
    {
        if (level < 2) return;

        Collider[] hits = Physics.OverlapSphere(transform.position, alertRadius);

        foreach (Collider hit in hits)
        {
            EnemyDetection other = hit.GetComponent<EnemyDetection>();
            if (other && other != detection)
                other.detectionValue = Mathf.Max(other.detectionValue, 0.66f);
        }
    }
}
