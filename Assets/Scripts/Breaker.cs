using UnityEngine;

public class Breaker : MonoBehaviour, InterfaceInteract
{

    // starts minigame when interacting with a breaker

    public Lockpick lockpick;

    public bool Interact(Interactor interactor)
    {

        lockpick.SpawnPicking();

        return true;

    }
}