using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractiveObject : MonoBehaviour
{
    protected bool interactRetry = false;

    protected bool clearInteract = false;

    private bool interactable = false;

    public bool Interactable
    {
        get
        {
            return interactable;
        }
        set
        {
            interactable = value;
            OnInteractableChanged(value);
        }
    }

    protected virtual void OnInteractableChanged(bool value) { }
}
