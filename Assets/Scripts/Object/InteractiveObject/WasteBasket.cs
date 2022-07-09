using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBasket : InteractiveObject
{
    protected override void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.APPLE)
        {
            GameManager.Instance.inventory.DeleteItem(EItemType.APPLE);
            GameManager.Instance.inventory.GainItem(EItemType.EATEN_APPLE);
        }
    }
}
