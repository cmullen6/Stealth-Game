using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelsPanel;

    void Start()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (levelsPanel != null) levelsPanel.SetActive(false);
    }

    public void OpenLevels()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (levelsPanel != null) levelsPanel.SetActive(true);
    }

    public void Back()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (levelsPanel != null) levelsPanel.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
