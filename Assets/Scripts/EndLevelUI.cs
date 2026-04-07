using UnityEngine;

public class EndLevelUI : MonoBehaviour
{
    public GameObject panel;

    private string nextScene;

    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    // Called by ExitDoor
    public void Show(string sceneName)
    {
        nextScene = sceneName;

        if (panel != null)
            panel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        if (!string.IsNullOrEmpty(nextScene))
        {
            GameManager.Instance.LoadScene(nextScene);
        }
        else
        {
            Debug.LogError("No next scene assigned!");
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene("MainMenu");
    }
}