using UnityEngine;

public class ShadowZone : MonoBehaviour
{
    public CanvasGroup overlay;
    public float fadeSpeed = 5f;

    static int playerInShadows = 0; // supports overlapping zones
    float targetAlpha = 0f;

    private Animator animator;

    void Start()
    {

        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (overlay == null) return;

        overlay.alpha = Mathf.Lerp(
            overlay.alpha,
            targetAlpha,
            Time.deltaTime * fadeSpeed
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInShadows++;
        targetAlpha = 0.5f;

        animator.SetBool("Hiding", true);

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInShadows--;
        if (playerInShadows <= 0)
        {
            playerInShadows = 0;
            targetAlpha = 0f;

            animator.SetBool("Hiding", false);

        }
    }

    public static bool PlayerInShadow()
    {
        return playerInShadows > 0;
    }
}