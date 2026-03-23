using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public EnemyDetection enemy;

    [Header("Feet UI")]
    public Slider detectionBar;

    [Header("Head UI")]
    public GameObject alertIcon;
    public TextMeshProUGUI alertText;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!enemy || cam == null) return;

        FaceCamera();

        UpdateDetectionBar();
        UpdateAlertUI();
    }

    void FaceCamera()
    {
        Vector3 dir = transform.position - cam.transform.position;
        dir.y = 0; // prevents tilt
        transform.rotation = Quaternion.LookRotation(dir);
    }

    void UpdateDetectionBar()
    {
        if (detectionBar == null) return;

        detectionBar.value = enemy.detectionValue;

        Image fillImage = detectionBar.fillRect.GetComponent<Image>();

        if (fillImage != null)
        {
            fillImage.color = Color.Lerp(Color.green, Color.red, enemy.detectionValue);
        }
    }

    void UpdateAlertUI()
    {
        if (enemy.alertLevel > 0)
        {
            if (alertIcon != null) alertIcon.SetActive(true);

            if (alertText != null)
            {
                alertText.gameObject.SetActive(true);
                alertText.text = enemy.alertLevel.ToString();
            }
        }
        else
        {
            if (alertIcon != null) alertIcon.SetActive(false);
            if (alertText != null) alertText.gameObject.SetActive(false);
        }
    }
}