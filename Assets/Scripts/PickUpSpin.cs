using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 100f; // degrees per second

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
