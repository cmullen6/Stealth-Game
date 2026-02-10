using UnityEngine;

public class VisionConeRenderer : MonoBehaviour
{
    public EnemyDetection detection;
    public MeshRenderer cone;

    void Update()
    {
        cone.transform.localScale =
            new Vector3(detection.visionRange, 1, detection.visionRange);

        cone.enabled = detection.alertLevel > 0;
    }
}
