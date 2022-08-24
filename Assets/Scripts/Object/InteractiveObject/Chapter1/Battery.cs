using UnityEngine;

public class Battery : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_BATTERY);
        gameObject.SetActive(false);
        GameManager.Instance.saveData.SaveMapItem(this);
    }
}
