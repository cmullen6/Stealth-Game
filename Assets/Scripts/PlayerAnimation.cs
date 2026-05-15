using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    // Some animations are in specific scripts such as lockpicking

    private Animator animator;

    public AudioClip[] jumpSounds;
    public AudioClip walkSound;
    public AudioClip runSound;

    
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

                SoundFXManager.instance.PlayRandomSoundFXClip(jumpSounds, transform, 1f);


                animator.SetTrigger("Jump");

            }

            if (Keyboard.current.leftShiftKey.isPressed && (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed))
            {

                //SoundFXManager.instance.PlaySoundFXClip(runSound, transform, 1f);


                animator.SetBool("Run", true);

            }
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
            {

               // SoundFXManager.instance.PlaySoundFXClip(walkSound, transform, 1f);

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
