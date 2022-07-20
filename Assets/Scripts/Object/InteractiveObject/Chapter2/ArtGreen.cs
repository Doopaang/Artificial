using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGreen : MonoBehaviour
{
    private bool usedItem = false;

    public void Interact()
    {
        if (!usedItem &&
            GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER2_FLOWER)
        {
            usedItem = true;
            GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_KEY_GREEN);
        }
    }
}
