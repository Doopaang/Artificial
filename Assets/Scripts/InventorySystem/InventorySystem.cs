//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventorySystem : MonoBehaviour
//{
//    InventoryUI inventoryUI;

//    public List<ItemData> itemDictionary;

//    List<EItemType> curItemList;

//    EItemType curUsingItem;

//    bool bReadyCombine;

//    private void Awake()
//    {
//        curUsingItem = EItemType.NONE;

//        curItemList = new List<EItemType>();

//        inventoryUI = gameObject.GetComponent<InventoryUI>();
//    }

//    public void UseItem()
//    {
//        if (inventoryUI.GetCurrentSelectedItemSlot() &&
//            inventoryUI.GetCurrentSelectedItemSlot().GetItemData().itemType == EItemType.NONE)
//        {
//            return;
//        }

//        curUsingItem = inventoryUI.GetCurrentSelectedItemSlot().GetItemData().itemType;

//        inventoryUI.DeactivateInventoryUI();
//    }

//    public void GainItem(EItemType itemType)
//    {
//        if (inventoryUI.itemSlotList.Count <= curItemList.Count)
//            return;

//        curItemList.Add(itemType);
//        inventoryUI.ApplyInventory();
//    }

//    public void DeleteItem(ItemSlot itemSlot)
//    {
//        for (int i = 0; i < curItemList.Count; i++)
//        {
//            if (curItemList[i] == itemSlot.GetItemData().itemType)
//            {
//                curItemList.RemoveAt(i);
//                break;
//            }
//        }

//        ItemData itemData = new ItemData();
//        itemData.itemType = EItemType.NONE;
//        itemData.sprite = itemSlot.slotImage.sprite;

//        itemSlot.ChangeItem(itemData);
//        itemSlot.selectedImage.gameObject.SetActive(false);

//        inventoryUI.ApplyInventory();
//    }

//    public List<ItemData> GetItemDictionary()
//    {
//        return itemDictionary;
//    }

//    public List<EItemType> GetCurrentItemList()
//    {
//        return curItemList;
//    }

//    public void ActivateCombine()
//    {
//        bReadyCombine = true;
//    }

//    public void DeactivateCombine()
//    {
//        bReadyCombine = false;
//    }

//    public bool IsReadyCombine()
//    {
//        return bReadyCombine;
//    }

//}
