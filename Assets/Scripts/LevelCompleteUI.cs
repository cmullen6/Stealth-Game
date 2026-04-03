using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void Show()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLevel(string sceneName)
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene(sceneName);
    }
}