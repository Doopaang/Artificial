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
            GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER2_KNIFE)
        {
            GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
            usedItem = true;

            // (미구현) 암전
            
            red.ChangeArt();

            GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        }
    }
}
