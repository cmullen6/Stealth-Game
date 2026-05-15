using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject howToPlayPanel;
    public GameObject storyPanel;
    public GameObject[] htpInfo;
    private int infoPage = 0;
    public AudioClip buttonPress;


    // Makes sure only mainPanel is on on start
    void Start()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (creditsPanel != null) creditsPanel.SetActive(false);
        if (howToPlayPanel != null)
        {

            howToPlayPanel.SetActive(false);

            for (int i = 0; i < htpInfo.Length; i++)
            {

                htpInfo[i].SetActive(false);

            }

        }
        if (storyPanel != null) storyPanel.SetActive(false);

    }

    // Opens creditsPanel
    public void Credits()
    {
        
        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            creditsPanel.SetActive(true);

        }
       
    }

    // Opens storyPanel
    public void Story()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            storyPanel.SetActive(true);

        }

    }

    // Opens howToPlayPanel
    public void HowToPlay()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (mainPanel != null)
        {

            mainPanel.SetActive(false);

            howToPlayPanel.SetActive(true);

            htpInfo[infoPage].SetActive(true);

        }
       
    }

    //scrolls through how to play pages
    public void HTPNext()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (howToPlayPanel != null)
        {

            htpInfo[infoPage].SetActive(false);

            infoPage++;

            if (infoPage >= htpInfo.Length)
            {

                infoPage = 0;

            }

            htpInfo[infoPage].SetActive(true);

        }

    }

    public void HTPPrev()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (howToPlayPanel != null)
        {

            htpInfo[infoPage].SetActive(false);

            infoPage--;

            if (infoPage <= htpInfo.Length)
            {

                infoPage = 4;

            }

            htpInfo[infoPage].SetActive(true);

        }     

    }

    // Will retrun to only mainPanel on and turns off the appropriate panel
    public void Back()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);

        if (creditsPanel != null)
        {

            creditsPanel.SetActive(false);

            mainPanel.SetActive(true);

        }

        if (howToPlayPanel != null)
        {

            howToPlayPanel.SetActive(false);

            htpInfo[infoPage].SetActive(false);

            mainPanel.SetActive(true);

        }

        if (storyPanel != null)
        {

            storyPanel.SetActive(false);

            mainPanel.SetActive(true);

        }

    }

    // Quits game
    public void Quit()
    {

        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);


        Application.Quit();

    }
}
