using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    private EItemType itemType;

    private Image slotImage;

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
    private void Awake()
    {
        slotImage = GetComponent<Image>();
    }

    private void Start()
    {
        if (slotImage.rectTransform.sizeDelta != Vector2.zero)
            itemImage.rectTransform.sizeDelta = slotImage.rectTransform.sizeDelta;
    }

    public void ChangeItem(EItemType newItemType)
    {
        Item newItemData = GameManager.Instance.inventory.SearchItemData(newItemType);

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
    }
}
