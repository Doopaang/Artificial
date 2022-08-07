using UnityEngine;

public class KeyYellow : MonoBehaviour
{
    public void Interact()
    {
        if(GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_HOOK)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_HOOK);
            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_YELLOW);
            Destroy(gameObject);
        }
    }
}
