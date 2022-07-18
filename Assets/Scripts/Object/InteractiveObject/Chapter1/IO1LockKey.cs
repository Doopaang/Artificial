using UnityEngine;

public class IO1LockKey : MonoBehaviour
{
    protected void Interact()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_KEY);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_BATTERY);
    }
}
