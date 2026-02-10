using UnityEngine;

public class LookoutEnemy : MonoBehaviour
{
    public float baseTurnSpeed = 90f;
    float currentTurnSpeed;

    EnemyDetection detection;

    void Awake()
    {
        detection = GetComponent<EnemyDetection>();
        detection.OnAlertLevelChanged += UpdateAlertness;
    }

    void Start()
    {
        UpdateAlertness(0);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * currentTurnSpeed * Time.deltaTime);
    }

    void UpdateAlertness(int level)
    {
        currentTurnSpeed = baseTurnSpeed + (level * 60f);
    }
}

