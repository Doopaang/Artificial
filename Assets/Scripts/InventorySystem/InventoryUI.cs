//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryUI : MonoBehaviour
//{
//    public List<GameObject> itemSlotList;

//    public Image inventoryUI;

//    public Image itemDetailUI;

//    public Image itemImage;

//    ItemSlot curSelectedItemSlot;

//    public void Start()
//    {
//        for (int i = 0; i < itemSlotList.Count; i++)
//            itemSlotList[i].GetComponent<ItemSlot>().SetInventoryUI(this);

//        gameObject.SetActive(false);
//    }

//    public ItemSlot GetCurrentSelectedItemSlot()
//    {
//        return curSelectedItemSlot;
//    }

//    public void ApplyInventory()
//    {
//        Inventory inventory = GameManager.Instance.inventory;
//        List<EItemType> curItemList = inventory.GetCurrentItemList();
//        List<ItemData> itemDictionary = inventory.GetItemDictionary();

//        for (int i = 0; i < itemSlotList.Count; i++)
//        {
//            if (i >= curItemList.Count)
//                inventory.DeleteItem(itemSlotList[i].GetComponent<ItemSlot>());
//            else
//                itemSlotList[i].GetComponent<ItemSlot>().ChangeItem(itemDictionary[(int)curItemList[i]]);
//        }
//    }

//    public void ApplySelectedItemSlot(ItemSlot newSelectedItemSlot)
//    {
//        if (!curSelectedItemSlot)
//        {
//            curSelectedItemSlot = newSelectedItemSlot;
//            curSelectedItemSlot.selectedImage.gameObject.SetActive(true);
//            return;
//        }

//        curSelectedItemSlot.selectedImage.gameObject.SetActive(false);

//        if (curSelectedItemSlot == newSelectedItemSlot)
//        {
//            curSelectedItemSlot = null;
//            return;
//        }

//        curSelectedItemSlot = newSelectedItemSlot;
//        curSelectedItemSlot.selectedImage.gameObject.SetActive(true);
//    }

//    public void ActivateInventoryUI()
//    {
//        gameObject.SetActive(true);

//        GameManager.Instance.IncreaseActivatedUINum();
//    }

//    public void DeactivateInventoryUI()
//    {
//        gameObject.SetActive(false);

//        GameManager.Instance.DecreaseActivatedUINum();

//        if (curSelectedItemSlot)
//        {
//            curSelectedItemSlot.selectedImage.gameObject.SetActive(false);

//            curSelectedItemSlot = null;
//        }
//    }

//    public void ActivateItemDetailUI()
//    {
//        if (!curSelectedItemSlot || curSelectedItemSlot.GetItemData().itemType == EItemType.NONE)
//            return;

//        itemDetailUI.gameObject.SetActive(true);
//        itemImage.sprite = curSelectedItemSlot.itemImage.sprite;

//        GameManager.Instance.IncreaseActivatedUINum();
//    }

//    public void DeactivateItemDetailUI()
//    {
//        itemDetailUI.gameObject.SetActive(false);

//        GameManager.Instance.DecreaseActivatedUINum();
//    }

//}
