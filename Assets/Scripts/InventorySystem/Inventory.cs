using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Slot[] slotList;

    private List<Item> itemList;

    private Slot selectedSlot;

    private EItemType usingItem = EItemType.NONE;

    [SerializeField]
    private Image selectedImage;

    [SerializeField]
    private DetailWindow itemDetailWindow;

    [SerializeField]
    private UsingItem usingItemUI;

    private bool bActivatedCombine;

    public EItemType UsingItem
    {
        get
        {
            return usingItem;
        }
    }

    public bool IsActivatedCombine
    {
        get
        {
            return bActivatedCombine;
        }
    }

    public UsingItem UsingItemUI
    {
        get
        {
            return usingItemUI;
        }
    }

    private void Start()
    {
        slotList = GetComponentsInChildren<Slot>();
        itemList = new List<Item>();

        DeactiveInventory();
        itemDetailWindow.gameObject.SetActive(false);
    }

    public void ClearItem()
    {
        SetUsingItem(EItemType.NONE);
    }

    private void ApplyItemList()
    {
        for (int i = 0; i < slotList.Length; i++)
        {
            if (i < itemList.Count)
                slotList[i].ChangeItem(itemList[i].itemType);
            else
                slotList[i].ChangeItem(EItemType.NONE);
        }
    }

    public void ApplySelectedItemSlot(Slot newSelectedItemSlot)
    {
        selectedImage.gameObject.SetActive(false);

        if (selectedSlot && selectedSlot == newSelectedItemSlot)
        {
            selectedSlot = null;
            return;
        }

        selectedSlot = newSelectedItemSlot;
        selectedImage.gameObject.SetActive(true);
        selectedImage.gameObject.GetComponent<RectTransform>().position = selectedSlot.ItemObject.gameObject.transform.position;
    }

    public void GainItem(EItemType itemType)
    {
        if (itemList.Count >= slotList.Length)
            return;

        itemList.Add(SearchItemData(itemType));

        ApplyItemList();

        ActivateItemDetailWindow(itemType);
    }

    public void PressedUseButton()
    {
        if (!selectedSlot)
            return;

        SetUsingItem(selectedSlot.ItemType);

        DeactiveInventory();
    }

    public void Combine(EItemType otherItem)
    {
        DeactivateCombine();

        if (!selectedSlot)
            return;

        EItemType resultItemType = SearchItemData(otherItem).combineResultItemType;

        if (resultItemType == EItemType.NONE ||
            SearchItemData(selectedSlot.ItemType).combinableItemType != otherItem)
        {
            return;
        }

        DeleteItem(selectedSlot.ItemType);
        DeleteItem(otherItem);
        GainItem(resultItemType);

        selectedSlot = null;
        selectedImage.gameObject.SetActive(false);
    }

    public void PressedDetailButton()
    {
        if (selectedSlot)
            ActivateItemDetailWindow(selectedSlot.ItemType);
    }

    public void ActivateItemDetailWindow(EItemType itemType)
    {
        if (itemType == EItemType.NONE)
            return;

        itemDetailWindow.SetDetailObject(SearchItemData(itemType).gameObject);

        itemDetailWindow.gameObject.SetActive(true);
    }

    public Item SearchItemData(EItemType itemType)
    {
        List<Item> itemDictionary = GameManager.Instance.itemDictionary;

        for (int i = 0; i < itemDictionary.Count; i++)
        {
            if (itemDictionary[i].itemType == itemType)
                return itemDictionary[i];
        }

        throw new System.Exception();
    }

    public void DeleteItem(EItemType itemType)
    {
        if (itemType == EItemType.NONE)
            return;

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemType == itemType)
            {
                if (itemType == usingItem)
                {
                    SetUsingItem(EItemType.NONE);
                    Destroy(GameManager.Instance.Inventory.UsingItemUI.UsingItemObject);
                }

                itemList.RemoveAt(i);
                ApplyItemList();
                return;
            }
        }
    }

    public void ActivateCombine()
    {
        if (!selectedSlot)
            return;

        bActivatedCombine = true;
    }

    public void DeactivateCombine()
    {
        bActivatedCombine = false;
    }

    public void ActivateInventory()
    {
        gameObject.SetActive(true);

        DeactivateCombine();

        SetUsingItem(EItemType.NONE);
    }

    public void DeactiveInventory()
    {
        gameObject.SetActive(false);

        selectedSlot = null;

        selectedImage.gameObject.SetActive(false);
    }

    private void SetUsingItem(EItemType itemType)
    {
        usingItem = itemType;

        usingItemUI.SetItem(UsingItem);
    }
}
