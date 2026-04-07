using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public EnemyDetection enemy;

    public Slider detectionBar;
    public GameObject alertIcon;
    public TMPro.TextMeshProUGUI alertText;

    public Vector3 barOffset = new Vector3(0, 0.1f, 0);   // feet
    public Vector3 iconOffset = new Vector3(0, 2.2f, 0);  // head

    Camera cam;
    private void Update()
    {
        Debug.Log(enemy.detectionValue);
    }
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (enemy == null || cam == null) return;

        // ===== FACE CAMERA (NO SPIN)
        Vector3 dir = transform.position - cam.transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);

        // ===== BAR POSITION (FEET)
        if (detectionBar != null)
        {
            detectionBar.transform.position = enemy.transform.position + barOffset;

            detectionBar.value = enemy.detectionValue;
        }

        // ===== ALERT ICON (HEAD)
        if (alertIcon != null)
        {
            alertIcon.transform.position = enemy.transform.position + iconOffset;

            bool show = enemy.alertLevel > 0;
            alertIcon.SetActive(show);

            if (show && alertText != null)
            {
                alertText.text = enemy.alertLevel.ToString();
            }
        }
    }

}