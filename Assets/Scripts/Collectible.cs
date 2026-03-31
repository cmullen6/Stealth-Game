using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;
    //public int timer = 0;
    //public InteractUI interactUI;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
       

        GameManager.Instance.AddScore(value);
        Destroy(gameObject);
    }
}

