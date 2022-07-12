using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected EItemType interactiveItem;

    [SerializeField]
    protected EItemType gainItem;

    [SerializeField]
    protected EItemType deleteItem;

    public bool bInteractable;

    public void OnMouseDown()
    {
        if (!GameManager.Instance.EnableClickObject && bInteractable &&
            GameManager.Instance.inventory.UsingItem == interactiveItem)
        {
            return;
        }

        Interact();
    }

    protected abstract void Interact();
}
