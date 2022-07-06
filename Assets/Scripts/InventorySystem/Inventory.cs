using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ItemData
{
    public EItemType ItemType;

    public Sprite sprite;
}

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;

    public List<ItemData> itemDictionary;

    List<EItemType> curItemList;

    void Start()
    {
        curItemList = new List<EItemType>();
    }

    public void GainItem(EItemType itemType)
    {
        curItemList.Add(itemType);

        inventoryUI.ApplyInventory(this);
    }

    public List<ItemData> GetItemDictionary()
    {
        return itemDictionary;
    }

    public List<EItemType> GetCurrentItemList()
    {
        return curItemList;
    }

}
