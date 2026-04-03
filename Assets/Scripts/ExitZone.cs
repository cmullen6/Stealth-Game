using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject readyIndicator;

    void Update()
    {
        if (GameManager.Instance == null) return;

        bool ready = GameManager.Instance.HasMetRequirement;

        if (readyIndicator != null)
            readyIndicator.SetActive(ready);
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.Instance.HasMetRequirement)
            {
                GameManager.Instance.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Need more pickups!");
            }
        }
    }
}