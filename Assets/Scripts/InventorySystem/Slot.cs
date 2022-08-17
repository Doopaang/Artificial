using UnityEngine;

public class Slot : MonoBehaviour
{
    private EItemType itemType;

    [SerializeField]
    private GameObject transformObject;

    [SerializeField]
    private GameObject itemObject;

    public EItemType ItemType
    {
        get
        {
            return itemType;
        }
    }

    public GameObject ItemObject
    {
        get
        {
            return itemObject;
        }
    }

    public void ChangeItem(EItemType newItemType)
    {
        Item newItemData = GameManager.Instance.Inventory.SearchItemData(newItemType);

        if (itemType != EItemType.NONE)
        {
            Destroy(itemObject);
        }

        if (newItemData.itemType != EItemType.NONE)
        {
            itemObject = Instantiate(newItemData.itemObject,
                transformObject.transform.position, newItemData.itemRotation, transformObject.transform);

            itemObject.layer = LayerMask.NameToLayer("UI");

            itemObject.transform.localScale = newItemData.scaleInventory;

            if (itemObject.GetComponent<MeshRenderer>())
                itemObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            if (itemObject.GetComponent<Collider>())
                itemObject.GetComponent<Collider>().enabled = false;

            transform.tag = "Interact";
        }
        else
        {
            transform.tag = "Untagged";
        }

        itemType = newItemData.itemType;
    }

    public void OnClick()
    {
        if (itemType == EItemType.NONE)
            return;

        Inventory inventory = GameManager.Instance.Inventory;

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
