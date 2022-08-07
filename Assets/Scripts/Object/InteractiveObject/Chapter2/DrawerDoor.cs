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
    private Vector3 movementVectorForClose;

    [SerializeField]
    private bool locked = true;

    private bool opened = false;

    public void Interact()
    {
        if (LockKey != EItemType.NONE && GameManager.Instance.Inventory.UsingItem == LockKey)
        {
            GameManager.Instance.Inventory.DeleteItem(LockKey);
            Unlock();
        }
        else if (!locked)
        {
            TranslateDrawer();
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
        DialogueSystem.Instance.StartDialogue("UnlockDrawer");
        GameManager.Instance.Inventory.ClearItem();

        locked = false;
    }
}
