using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public EnemyDetection detection;
    public Transform cone;

    void Update()
    {
        if (!detection || !cone || detection.tuning == null) return;

        float range = detection.tuning.visionRange;

        // Always visible
        cone.gameObject.SetActive(true);

        // Scale cone
        cone.localScale = new Vector3(range, 1f, range);

        // Optional: color by alert level
        Renderer r = cone.GetComponent<Renderer>();
        if (r != null)
        {
            Color c =
                detection.alertLevel == 0 ? Color.green :
                detection.alertLevel == 1 ? Color.yellow :
                detection.alertLevel == 2 ? new Color(1f, 0.5f, 0f) :
                Color.red;

            c.a = 0.2f; // transparency
            r.material.color = c;
        }
    }
}
