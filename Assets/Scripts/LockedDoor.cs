using UnityEngine;

public class LockedDoor : MonoBehaviour, InterfaceInteract
{

    // starts minigame when interacting with a locked door

    public Lockpick lockpick;

    public bool Interact(Interactor interactor)
    {

        lockpick.SpawnPicking();

        return true;

    }
}
