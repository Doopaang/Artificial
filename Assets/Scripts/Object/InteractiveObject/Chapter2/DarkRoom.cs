using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : MonoBehaviour
{
    private bool usedItem = false;

    public void Interact()
    {
        if (!usedItem &&
            GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER2_FLASHLIGHT)
        {
            GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER2_FLASHLIGHT);
            usedItem = true;

            // (미구현) 방 밝히기

            Destroy(GetComponent<Collider>());
        }
    }
}
