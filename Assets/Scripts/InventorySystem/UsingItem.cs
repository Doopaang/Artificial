using UnityEngine;

public class UsingItem : MonoBehaviour
{
    [SerializeField]
    private GameObject transformObject;

    private GameObject usingItemObject;

    public BrushUI brushUI;

    public void SetItem(EItemType item)
    {
        if (item == EItemType.NONE)
            return;

        Item newItemData = GameManager.Instance.inventory.SearchItemData(item);

        if (usingItemObject)
            Destroy(usingItemObject);

        usingItemObject = Instantiate(newItemData.itemObject, 
            transformObject.transform.position, newItemData.itemRotation, transformObject.transform);

        usingItemObject.layer = LayerMask.NameToLayer("UI");
        usingItemObject.transform.localScale = newItemData.scaleUsing;
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
}
