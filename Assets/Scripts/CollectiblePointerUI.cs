using UnityEngine;

public class CollectiblePointerUI : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public RectTransform pointerUI;
    public Camera cam;

    [Header("Settings")]
    public float searchRadius = 20f;

    Transform currentTarget;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (player == null || cam == null) return;

        FindClosestCollectible();

        if (currentTarget == null)
            return;

        // WORLD DIRECTION (correct base)
        Vector3 worldDir = (currentTarget.position - player.position).normalized;

        // PROJECT ONTO CAMERA PLANE (this fixes everything)
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        // Remove vertical influence
        worldDir.y = 0;

        // Convert to camera-relative direction
        float x = Vector3.Dot(worldDir, camRight);
        float z = Vector3.Dot(worldDir, camForward);

        // FINAL ANGLE
        float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        pointerUI.rotation = Quaternion.Euler(0, 0, -angle);
    }

    void FindClosestCollectible()
    {
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");

        float closestDist = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject obj in collectibles)
        {
            float dist = Vector3.Distance(player.position, obj.transform.position);

            if (dist < searchRadius && dist < closestDist)
            {
                closestDist = dist;
                closest = obj.transform;
            }
        }

        currentTarget = closest;
    }
}
