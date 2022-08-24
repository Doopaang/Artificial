using UnityEngine;

public class ColorDialPuzzlePaper : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_COLOR_DIAL_PUZZLE_PAPER);
        gameObject.SetActive(false);
        GameManager.Instance.saveData.SaveMapItem(this);
    }
}
