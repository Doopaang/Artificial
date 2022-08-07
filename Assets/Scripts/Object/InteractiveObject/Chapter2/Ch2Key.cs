using UnityEngine;

public class Ch2Key : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY);
        Destroy(gameObject);
    }
}
