using UnityEngine;

public class UsingItem : MonoBehaviour
{
    [SerializeField]
    private GameObject transformObject;

    private GameObject usingItemObject;

    public BrushUI brushUI;

    public GameObject UsingItemObject
    {
        get
        {
            return usingItemObject;
        }
    }

    public void SetItem(EItemType item)
    {
        if (item == EItemType.NONE)
            return;

        Item newItemData = GameManager.Instance.Inventory.SearchItemData(item);

        if (usingItemObject)
            Destroy(usingItemObject);

        usingItemObject = Instantiate(newItemData.itemObject,
            transformObject.transform.position, newItemData.itemRotation, transformObject.transform);

        ChangeLayersRecursively(usingItemObject.transform);
        usingItemObject.transform.localScale = newItemData.scaleUsing;

        if (usingItemObject.GetComponent<MeshRenderer>())
            usingItemObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        SetSubCanvas(item, EItemType.CHAPTER2_BRUSH, brushUI.GetComponent<RectTransform>());
    }

    private void SetSubCanvas(EItemType curItem, EItemType itemType, RectTransform ui)
    {
        if (curItem == itemType)
        {
            ui.gameObject.SetActive(true);
        }
        else if (ui.gameObject.activeSelf)
        {
            ui.gameObject.SetActive(false);
        }
    }

    public void ChangeLayersRecursively(Transform trans)
    {
        trans.gameObject.layer = LayerMask.NameToLayer("UI");

        if (trans.GetComponent<MeshRenderer>())
            trans.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child);
        }
    }
}
