using UnityEngine;

public class LockForKey : MonoBehaviour
{
    [SerializeField]
    private CabinetDoor cabinetDoor;

    [HideInInspector]
    public bool opened = false;

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KEY);
            cabinetDoor.Unlock();

            Open();

            SoundSystem.Instance.PlaySFX("LockUnlock", transform.position);
        }
    }

    public void Open()
    {
        opened = true;
        gameObject.SetActive(false);
    }
}
