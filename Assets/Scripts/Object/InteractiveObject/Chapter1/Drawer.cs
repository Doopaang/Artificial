using UnityEngine;

public class Drawer : MonoBehaviour
{
    private bool opened = false;

    private bool locked = true;

    [SerializeField]
    private Vector3 movementVectorForClose;

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER1_KEY)
        {
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
        GameManager.Instance.Inventory.ClearItem();

        locked = false;
    }
}
