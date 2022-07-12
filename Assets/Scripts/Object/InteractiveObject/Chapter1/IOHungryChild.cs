using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOHungryChild : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
    }
}
