using UnityEngine;

public class ArtBlue : MonoBehaviour
{
    private bool usedItem = false;

    public void Interact()
    {
        if (!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_BRUSH &&
            GameManager.Instance.brushColor == new Color(1.0f, 1.0f, 0.0f, 1.0f))
        {
            usedItem = true;
            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_BLUE);
        }
    }
}
