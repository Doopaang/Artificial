using UnityEngine;

public class Apple : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_APPLE);
        gameObject.SetActive(false);
        GameManager.Instance.saveData.SaveMapItem(this);
    }
}
