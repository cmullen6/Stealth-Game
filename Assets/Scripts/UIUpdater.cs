using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if (GameManager.Instance == null) return;

        timerText.text = Mathf.CeilToInt(GameManager.Instance.Timer).ToString();
        scoreText.text = "$" + GameManager.Instance.Score;
    }
}
