using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_FLASHLIGHT);
        Destroy(gameObject);
    }
}
