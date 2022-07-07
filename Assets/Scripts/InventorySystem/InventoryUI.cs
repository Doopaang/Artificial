using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> itemSlotList;

    ItemSlot curSelectedItemSlot;

    public void Start()
    {
        for (int i = 0; i < itemSlotList.Count; i++)
            itemSlotList[i].GetComponent<ItemSlot>().SetInventoryUI(this);
    }

    public void ApplyInventory(Inventory inventory)
    {
        List<EItemType> curItemList = inventory.GetCurrentItemList();
        List<ItemData> itemDictionary = inventory.GetItemDictionary();

        for (int i = 0; i < curItemList.Count; i++)
        {
            itemSlotList[i].GetComponent<ItemSlot>().ChangeItem(itemDictionary[(int)curItemList[i]]);
        }
    }

    public void ApplySelectedItemSlot(ItemSlot newSelectedItemSlot)
    {
        if (!curSelectedItemSlot)
        {
            curSelectedItemSlot = newSelectedItemSlot;
            curSelectedItemSlot.selectedImage.gameObject.SetActive(true);
            return;
        }

        curSelectedItemSlot.selectedImage.gameObject.SetActive(false);

        if (curSelectedItemSlot == newSelectedItemSlot)
        {
            curSelectedItemSlot = null;
            return;
        }

        curSelectedItemSlot = newSelectedItemSlot;
        curSelectedItemSlot.selectedImage.gameObject.SetActive(true);
    }

}
