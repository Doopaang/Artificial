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

    public void OnMouseDown()
    {
        if (!GameManager.Instance.EnableClickObject)
            return;

        Interact();
    }

    protected virtual void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == interactiveItem)
        {
            GameManager.Instance.inventory.DeleteItem(deleteItem);
            GameManager.Instance.inventory.GainItem(gainItem);
        }
    }
}
