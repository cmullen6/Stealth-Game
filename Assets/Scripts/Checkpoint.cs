using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint Current;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Current = this;
    }
}
