using UnityEngine;

public class NoiseEmitter : MonoBehaviour
{
    public float walkNoise = 3f;
    public float sprintNoise = 6f;
    public float crouchNoise = 1.5f;
    public float jumpNoise = 5f;

    public Transform noiseVisual;

    Camera cam;
    float currentRadius;

    void Start()
    {
        cam = Camera.main;

        if (noiseVisual != null)
            noiseVisual.localScale = Vector3.zero;
    }

    void LateUpdate()
    {
        if (noiseVisual == null || cam == null)
            return;

        noiseVisual.LookAt(noiseVisual.position + cam.transform.forward);
        noiseVisual.localScale = Vector3.one * currentRadius * 2f;
    }

    public void Emit(float amount)
    {
        currentRadius = amount;
        CancelInvoke(nameof(ClearNoise));
        Invoke(nameof(ClearNoise), 0.25f);
    }

    void ClearNoise()
    {
        currentRadius = 0f;
    }

    public float GetRadius() => currentRadius;
}

