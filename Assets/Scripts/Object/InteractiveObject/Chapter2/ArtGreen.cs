using UnityEngine;

public class ArtGreen : MonoBehaviour
{
    private bool usedItem = false;

    public void Interact()
    {
        if (!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLOWER)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_FLOWER);
            usedItem = true;
            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_GREEN);
        }
    }
}
