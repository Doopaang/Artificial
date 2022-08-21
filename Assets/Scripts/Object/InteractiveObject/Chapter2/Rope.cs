using UnityEngine;

public class Rope : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_ROPE);
        Destroy(gameObject);
    }
}
