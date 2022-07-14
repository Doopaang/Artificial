using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected EItemType interactiveItem;

    [HideInInspector]
    public bool bInteractable = false;

    public void OnMouseDown()
    {
        if (!bInteractable ||
            EventSystem.current.IsPointerOverGameObject() ||
            GameManager.Instance.inventory.UsingItem != interactiveItem)
        {
            return;
        }

        Interact();
    }

    protected abstract void Interact();
}
