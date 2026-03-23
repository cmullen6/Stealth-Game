using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if (GameManager.Instance == null) return;

        panel.SetActive(GameManager.Instance.IsGameOver);
    }

    public void Restart()
    {
        GameManager.Instance.ReloadFromCheckpoint();
    }

    public void MainMenu()
    {
        GameManager.Instance.ReturnToMainMenu();
    }
}
