using UnityEngine;

public class Drawer : MonoBehaviour
{
    [HideInInspector]
    public bool opened = false;

    public bool locked;

    [SerializeField]
    private Vector3 movementVectorForClose;

    public void Interact()
    {
        if (locked && GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER1_KEY)
        {
            Unlock();
        }
        else if (!locked)
        {
            TranslateDrawer();
        }
        else
        {
            SoundSystem.Instance.PlaySFX("Locked", transform.position);
        }
    }

    public void TranslateDrawer()
    {
        int translateDirection = opened ? 1 : -1;

        transform.Translate(translateDirection * movementVectorForClose, Space.Self);

        opened = !opened;

        SoundSystem.Instance.PlaySFX("Drawer", transform.position);
    }

    public void Unlock()
    {
        GameManager.Instance.Inventory.ClearItem();

        locked = false;

        SoundSystem.Instance.PlaySFX("LockUnlock", transform.position);
    }
}
