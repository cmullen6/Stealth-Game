using UnityEngine;
using UnityEngine.UI;

public class DetectionMeterUI : MonoBehaviour
{
    public Slider meter;

    void Update()
    {
        float highestDetection = 0f;

        EnemyDetection[] enemies =
            Object.FindObjectsByType<EnemyDetection>(FindObjectsSortMode.None);

        foreach (EnemyDetection enemy in enemies)
        {
            if (enemy.detectionValue > highestDetection)
                highestDetection = enemy.detectionValue;
        }

        meter.value = highestDetection;
    }
}

