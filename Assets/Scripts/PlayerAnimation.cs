using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    
    void Start()
    {
        
        animator = GetComponent<Animator>();

    }

   
    void Update()
    {

        if (animator != null)
        {

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {

                animator.SetTrigger("Jump");

            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {

                // lockpick

            }


        }

    }
}
