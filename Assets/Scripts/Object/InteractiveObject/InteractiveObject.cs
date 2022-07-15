using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected EItemType interactiveItem;

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

    public void OnMouseDown()
    {
        if (!interactable ||
            GameManager.Instance.inventory.UsingItem != interactiveItem)
        {
            return;
        }

        Interact();
    }

    protected abstract void Interact();

    protected virtual void OnInteractableChanged(bool value) { }
}
