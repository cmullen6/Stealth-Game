using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    // Some animations are in specific scripts such as lockpicking

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

            if (Keyboard.current.leftShiftKey.wasPressedThisFrame && (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame))
            {

                animator.SetBool("Run", true);


            }
            else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
            {

                animator.SetBool("Walk", true);


            }
            else
            {

                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);

            }

        }

    }
}
