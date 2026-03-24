using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Interactor : MonoBehaviour
{

    //Code for element that checks for locked doors and turns on / off UI

    public Transform interactionPoint;
    public float interactionRange = 0.25f;
    public LayerMask interactionMask;

    private readonly Collider[] colliders = new Collider[2];

    public int numFound;

    private InterfaceInteract interactable;

    public InteractUI interactUI;


    private void Update()
    {
        
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRange, colliders, interactionMask);

        
        if (numFound > 0)
        {

            interactable = colliders[0].GetComponent<InterfaceInteract>();

            if (interactable != null)
            {

                if (!interactUI.IsDisplayed)
                {

                    interactUI.ShowUp();

                }

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {

                    interactable.Interact(this);

                }
            }
        }
        else
        {

            if (interactable != null)
            {

                interactable = null;

            }

            if (interactUI.IsDisplayed)
            {

                interactUI.GoAway();

            }

        }

    }

    //Creates gizmo for detection of interactable objects
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.darkGreen;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);

    }
}
