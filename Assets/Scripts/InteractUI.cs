using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{

    //Turns interaction UI off and on

    public GameObject uiPanel;
    public bool IsDisplayed = false;


    void Start()
    {
        
        uiPanel.SetActive(false);

    }


    public void ShowUp()
    {

        uiPanel.SetActive(true);
        IsDisplayed = true;

    }


    public void GoAway()
    {

        uiPanel.SetActive(false);
        IsDisplayed = false;

    }
    
}