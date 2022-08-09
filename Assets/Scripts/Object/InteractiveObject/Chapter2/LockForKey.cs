using UnityEngine;

public class LockForKey : MonoBehaviour
{
    [SerializeField]
    private CabinetDoor cabinetDoor;

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KEY);
            cabinetDoor.Unlock();
            Destroy(gameObject);
        }
    }
}
