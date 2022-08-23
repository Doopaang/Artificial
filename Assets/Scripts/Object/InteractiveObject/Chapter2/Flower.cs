using UnityEngine;

public class Flower : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_FLOWER);
        Destroy(gameObject);
        GameManager.Instance.saveData.SaveMapItem(this);
    }
}
