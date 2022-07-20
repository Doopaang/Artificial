using UnityEngine;

public class ColorDialPuzzlePaper : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_COLOR_DIAL_PUZZLE_PAPER);
        gameObject.SetActive(false);
    }
}
