using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private ArtRed red;

    private bool usedItem = false;

    public void Interact()
    {
        if(!usedItem &&
            GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER3_TEMP3)
        {
            usedItem = true;

            // 임시 암전

            red.ChangeArt();

            GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        }
    }
}
