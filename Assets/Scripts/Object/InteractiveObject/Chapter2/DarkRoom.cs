using UnityEngine;

public class DarkRoom : MonoBehaviour
{
    private bool usedItem = false;

    public void Interact()
    {
        if (!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLASHLIGHT)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_FLASHLIGHT);
            usedItem = true;

            Destroy(GetComponent<Collider>());
        }
    }
}
