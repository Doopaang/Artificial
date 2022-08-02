using UnityEngine;
using UnityEngine.UI;

public class UsingItem : MonoBehaviour
{
    [SerializeField]
    private GameObject transformObject;

    private GameObject usingItemObject;

    public BrushUI brushUI;

    public void SetItem(EItemType item)
    {
        usingItemObject = GameManager.Instance.itemDictionary.Find((A) => { return A.itemType == item; }).itemObject;

        Instantiate(usingItemObject, transformObject.transform.position, 
            transformObject.transform.rotation, transformObject.transform);

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
