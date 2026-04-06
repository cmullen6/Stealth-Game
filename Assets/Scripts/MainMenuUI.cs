using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelsPanel;
    public GameObject howToPlayPanel;
    public GameObject storyPanel;

    // Makes sure only mainPanel is on on start
    void Start()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (levelsPanel != null) levelsPanel.SetActive(false);
        if (howToPlayPanel != null) howToPlayPanel.SetActive(false);
        if (storyPanel != null) storyPanel.SetActive(false);

    }

    // Opens levelsPanel
    public void OpenLevels()
    {
        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            levelsPanel.SetActive(true);

        }
       
    }

    // Opens storyPanel
    public void Story()
    {
        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            storyPanel.SetActive(true);

        }

    }

    // Opens howToPlayPanel
    public void HowToPlay()
    {
        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            howToPlayPanel.SetActive(true);

        }
       
    }

    // Will retrun to only mainPanel on and turns off the appropriate panel
    public void Back()
    {
        if (levelsPanel != null)
        {

            levelsPanel.SetActive(false);

            mainPanel.SetActive(true);

        }

        if (howToPlayPanel != null)
        {

            howToPlayPanel.SetActive(false);

            mainPanel.SetActive(true);

        }

        if (storyPanel != null)
        {

            storyPanel.SetActive(false);

            mainPanel.SetActive(true);

        }

    }

    // Loads specific level
    public void LoadLevel(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }

    // Quits game
    public void Quit()
    {
        Application.Quit();
    }
}
