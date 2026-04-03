using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int amount = 1;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager.Instance.AddPickup(amount);
        Destroy(gameObject);
    }
}

