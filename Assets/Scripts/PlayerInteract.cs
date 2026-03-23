using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float range = 3f;
    public LayerMask interactMask;

    public TextMeshProUGUI promptText;

    Interactable currentTarget;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact();
        }
    }

    void CheckForInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, interactMask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                currentTarget = interactable;
                promptText.gameObject.SetActive(true);
                return;
            }
        }

        currentTarget = null;
        promptText.gameObject.SetActive(false);
    }
}