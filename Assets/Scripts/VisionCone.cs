using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public EnemyDetection detection;
    public Transform cone;

    void Update()
    {
        if (detection == null || cone == null || detection.tuning == null) return;

        float range = detection.tuning.visionRange;
        float angle = detection.tuning.visionAngle;

        // Scale cone to match detection
        float radius = Mathf.Tan(angle * Mathf.Deg2Rad) * range;

        cone.localScale = new Vector3(radius, range * 0.5f, radius);

        // Position forward
        cone.localPosition = new Vector3(0, 0, range * 0.5f);

        // Always visible
        cone.gameObject.SetActive(true);

        // Color by alert level
        Renderer r = cone.GetComponent<Renderer>();
        if (r != null)
        {
            Color c =
                detection.alertLevel == 0 ? Color.green :
                detection.alertLevel == 1 ? Color.yellow :
                detection.alertLevel == 2 ? new Color(1f, 0.5f, 0f) :
                Color.red;

            c.a = 0.2f;
            r.material.color = c;
        }
    }
}