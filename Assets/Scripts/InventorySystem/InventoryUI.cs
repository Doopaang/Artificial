using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> itemSlotList;

    public void ApplyInventory(Inventory inventory)
    {
        List<EItemType> curItemList = inventory.GetCurrentItemList();
        List<ItemData> itemDictionary = inventory.GetItemDictionary();

        for (int i = 0; i < curItemList.Count; i++)
        {
            itemSlotList[i].GetComponent<ItemSlot>().ChangeItem(itemDictionary[(int)curItemList[i]]);
        }
    }

}
