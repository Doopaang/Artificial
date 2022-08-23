using UnityEngine;

public class FullMoon : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_FULL_MOON);
        Destroy(gameObject);
        GameManager.Instance.saveData.SaveMapItem(this);
    }
}
