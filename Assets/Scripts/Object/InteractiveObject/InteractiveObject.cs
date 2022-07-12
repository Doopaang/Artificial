using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
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
        if (!GameManager.Instance.EnableClickObject)
            return;

        Interact();
    }

    protected virtual bool Interact()
    {
        return bInteractable && GameManager.Instance.inventory.UsingItem == interactiveItem;
    }
}
