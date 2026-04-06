using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI timerText;
    //public TextMeshProUGUI pickupText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        // Timer
        timerText.text = Mathf.CeilToInt(GameManager.Instance.Timer).ToString();

        // Pickups (x / required)
        //pickupText.text =
           // GameManager.Instance.CurrentPickups + " / " +
           // GameManager.Instance.RequiredPickups;
    }
}
