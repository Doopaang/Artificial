using UnityEngine;

public class RedHandle : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        gameObject.SetActive(false);
    }
}
