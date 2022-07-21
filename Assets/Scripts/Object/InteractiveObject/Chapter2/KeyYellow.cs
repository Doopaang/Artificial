using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyYellow : MonoBehaviour
{
    public void Interact()
    {
        if(GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER2_HOOK)
        {
            GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER2_HOOK);
            GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_KEY_YELLOW);
            Destroy(gameObject);
        }
    }
}
