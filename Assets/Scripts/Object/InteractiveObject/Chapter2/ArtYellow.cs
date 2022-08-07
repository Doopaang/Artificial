using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private ArtRed red;

    private bool usedItem = false;

    public void Interact()
    {
        if(!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KNIFE)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
            usedItem = true;
            
            red.ChangeArt();

            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        }
    }
}
