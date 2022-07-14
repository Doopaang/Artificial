using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Debug.Log("onmousedown   " + !Interactable + "  " + EventSystem.current.IsPointerOverGameObject() + "  " + (GameManager.Instance.inventory.UsingItem != interactiveItem).ToString());

        if (!Interactable ||
            EventSystem.current.IsPointerOverGameObject() ||
            GameManager.Instance.inventory.UsingItem != interactiveItem)
        {
            return;
        }

        Interact();
    }

    protected virtual void OnInteractableChanged(bool value) { }

    protected abstract void Interact();
}
