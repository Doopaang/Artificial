using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    InventoryUI inventoryUI;

    public Image slotImage;

    public Image itemImage;

    public Image selectedImage;

    ItemData item;

    private void Start()
    {
        selectedImage.gameObject.SetActive(false);
    }

    private void Update()
    {

    }

    public void ChangeItem(ItemData newItem)
    {
        item = newItem;
        itemImage.sprite = item.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item.itemType == EItemType.NONE)
            return;

        inventoryUI.ApplySelectedItemSlot(this);
    }

    public void SetInventoryUI(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
    }
}
