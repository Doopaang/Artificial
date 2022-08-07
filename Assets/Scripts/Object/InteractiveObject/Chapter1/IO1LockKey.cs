using UnityEngine;

public class IO1LockKey : MonoBehaviour
{
    protected void Interact()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_KEY);
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_BATTERY);
    }
}
