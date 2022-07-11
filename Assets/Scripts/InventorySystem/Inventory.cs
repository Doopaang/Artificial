using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Slot[] slotList;

    private List<ItemData> itemList;

    private Slot selectedSlot;

    [SerializeField]
    private EItemType usingItem;

    [SerializeField]
    private Image selectedImage;

    [SerializeField]
    private Image itemDetailWindow;

    [SerializeField]
    private GameObject itemDetailObject;

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

    public GameObject ItemDetailObject
    {
        get
        {
            return itemDetailObject;
        }
    }

    public bool IsActivatedItemDetailWindow
    {
        get
        {
            return itemDetailWindow.gameObject.activeSelf;
        }
    }

    private void Start()
    {
        slotList = GetComponentsInChildren<Slot>();
        itemList = new List<ItemData>();

        gameObject.SetActive(false);

        DeactiveInventory();
        DeactivateItemDetailWindow();
        GameManager.Instance.InitActivatedUINum();
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

        ActivateItemDetailWindow(itemType);
    }

    public void PressedUseButton()
    {
        if (!selectedSlot)
            return;

        usingItem = selectedSlot.ItemType;

        DeactiveInventory();
    }

    public void Combine(EItemType otherItem)
    {
        DeactivateCombine();

        if (!selectedSlot)
            return;

        EItemType resultItemType = SearchItemData(otherItem).combineResultItemType;

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

        itemDetailWindow.gameObject.SetActive(true);

        itemDetailObject.GetComponent<MeshFilter>().mesh = SearchItemData(itemType).itemMesh;

        GameManager.Instance.IncreaseActivatedUINum();
    }

    public void DeactivateItemDetailWindow()
    {
        itemDetailWindow.gameObject.SetActive(false);

        itemDetailObject.transform.rotation = Quaternion.Euler(Vector3.zero);

        GameManager.Instance.DecreaseActivatedUINum();
    }

    public ItemData SearchItemData(EItemType itemType)
    {
        List<ItemData> itemDictionary = GameManager.Instance.itemDictionary;

        for (int i = 0; i < itemDictionary.Count; i++)
        {
            if (itemDictionary[i].itemType == itemType)
                return itemDictionary[i];
        }

        return new ItemData();
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
                    usingItem = EItemType.NONE;

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

        usingItem = EItemType.NONE;

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
