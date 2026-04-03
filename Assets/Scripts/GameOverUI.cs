using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance == null) return;

        if (panel != null)
            panel.SetActive(GameManager.Instance.IsGameOver);
    }

    public void Restart()
    {
        if (panel != null)
            panel.SetActive(false);

        GameManager.Instance.RestartLevel();
    }

    public void MainMenu()
    {
        if (panel != null)
            panel.SetActive(false);

        GameManager.Instance.LoadScene("MainMenu");
    }
}