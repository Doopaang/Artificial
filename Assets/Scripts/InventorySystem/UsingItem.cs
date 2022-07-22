using UnityEngine;
using UnityEngine.UI;

public class UsingItem : MonoBehaviour
{
    [SerializeField]
    private Image spriteImage;

    public BrushUI brushUI;

    public void SetItem(EItemType item)
    {
        spriteImage.sprite = GameManager.Instance.itemDictionary.Find((A) => { return A.itemType == item; }).itemSprite;
        spriteImage.enabled = spriteImage.sprite != null;

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
