using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Slot[] slotList;

    private List<ItemData> itemList;

    public List<ItemData> itemDictionary;

    private Slot selectedSlot;

    [SerializeField]
    private Image selectedImage;

    [SerializeField]
    private Image itemDetailWindow;

    [SerializeField]
    private Image itemDetailImage;

    private bool bActivatedCombine;

    public bool IsActivatedCombine
    {
        get
        {
            return bActivatedCombine;
        }
    }

    private void Start()
    {
        slotList = GetComponentsInChildren<Slot>();
        itemList = new List<ItemData>();

        gameObject.SetActive(false);
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
        selectedImage.gameObject.GetComponent<RectTransform>().position =
            selectedSlot.ItemImage.gameObject.GetComponent<RectTransform>().position;
    }

    public void GainItem(EItemType itemType)
    {
        if (itemList.Count >= slotList.Length)
            return;

        itemList.Add(SearchItemData(itemType));

        ApplyItemList();
    }

    public void Combine(EItemType otherItem)
    {
        EItemType resultItemType = SearchItemData(otherItem).combineResultItemType;

        DeleteItem(selectedSlot.ItemType);
        DeleteItem(otherItem);
        GainItem(resultItemType);

        DeactivateCombine();

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

        itemDetailWindow.gameObject.SetActive(true);

        itemDetailImage.sprite = SearchItemData(itemType).itemSprite;

        GameManager.Instance.IncreaseActivatedUINum();
    }

    public void DeactivateItemDetailWindow()
    {
        itemDetailWindow.gameObject.SetActive(false);

        GameManager.Instance.DecreaseActivatedUINum();
    }

    public ItemData SearchItemData(EItemType itemType)
    {
        for (int i = 0; i < itemDictionary.Count; i++)
        {
            if (itemDictionary[i].itemType == itemType)
                return itemDictionary[i];
        }

        return new ItemData();
    }

    public void DeleteItem(EItemType itemType)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemType == itemType)
            {
                itemList.RemoveAt(i);
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

        GameManager.Instance.IncreaseActivatedUINum();
    }

    public void DeactiveInventory()
    {
        gameObject.SetActive(false);

        selectedSlot = null;

        selectedImage.gameObject.SetActive(false);

        GameManager.Instance.DecreaseActivatedUINum();
    }
}
