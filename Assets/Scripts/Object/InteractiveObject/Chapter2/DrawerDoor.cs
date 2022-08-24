using UnityEngine;

public class DrawerDoor : MonoBehaviour
{
    [SerializeField]
    private EItemType LockKey;

    [SerializeField]
    private MoveSceneCamera moveCamera;

    [SerializeField]
    private GameObject doorModel;

    [SerializeField]
    private GameObject handle;

    [SerializeField]
    private Vector3 movementVectorForClose;

    public bool locked = true;

    [HideInInspector]
    public bool opened = false;

    public void Interact()
    {
        if (locked)
        {
            if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY_RED ||
                GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY_BLUE ||
                GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY_GREEN ||
                GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY_YELLOW ||
                GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY_BLACK)
            {
                if (GameManager.Instance.Inventory.UsingItem == LockKey)
                {
                    GameManager.Instance.Inventory.DeleteItem(LockKey);
                    GameManager.Instance.Inventory.ClearItem();

                    Unlock();
                }
                else
                    DialogueSystem.Instance.StartDialogue("Locker_Use_Diffrent_Handle");
            }
            else
                DialogueSystem.Instance.StartDialogue("Locker_Without_Item");
        }
        else if (!locked)
        {
            TranslateDrawer();
            SoundSystem.Instance.PlaySFX("Drawer", transform.position);
        }
    }

    public void TranslateDrawer()
    {
        int translateDirection = opened ? 1 : -1;

        transform.Translate(translateDirection * movementVectorForClose, Space.Self);

        opened = !opened;
    }

    public void Unlock()
    {
        locked = false;

        handle.SetActive(true);
    }
}
