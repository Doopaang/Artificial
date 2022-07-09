using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour//, IPointerClickHandler
{
    private EItemType itemType;

    [SerializeField]
    private Image itemImage;

    public EItemType ItemType
    {
        get
        {
            return itemType;
        }
    }

    public Image ItemImage
    {
        get
        {
            return itemImage;
        }
    }

    public void ChangeItem(EItemType newItemType)
    {
        ItemData newItemData = GameManager.Instance.inventory.SearchItemData(newItemType);

        itemType = newItemData.itemType;
        itemImage.sprite = newItemData.itemSprite;
    }

    public void OnClick()
    {
        if (itemType == EItemType.NONE)
            return;

        Inventory inventory = GameManager.Instance.inventory;

        if (!inventory.IsActivatedCombine)
        {
            inventory.ApplySelectedItemSlot(this);
        }
        else
        {
            inventory.Combine(itemType);
        }

        

        //if (inventory.IsReadyCombine())
        //{
        //    inventory.DeactivateCombine();

        //    if (inventoryUI.GetCurrentSelectedItemSlot() &&
        //        itemData.combinableItemType == inventoryUI.GetCurrentSelectedItemSlot().itemData.itemType)
        //    {
        //        inventory.DeleteItem(this);
        //        inventory.DeleteItem(inventoryUI.GetCurrentSelectedItemSlot());
        //    }

        //    Debug.Log("Combine");
        //}

        //inventoryUI.ApplySelectedItemSlot(this);
    }

    //public void SetInventoryUI(InventoryUI inventoryUI)
    //{
    //    this.inventoryUI = inventoryUI;
    //}

    //public ItemData GetItemData()
    //{
    //    return itemData;
    //}
}
