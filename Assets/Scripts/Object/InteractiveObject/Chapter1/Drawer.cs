using UnityEngine;

public class Drawer : MonoBehaviour
{
    private bool opened = false;

    [SerializeField]
    private bool locked;

    // 해당 변수는 추가됨
    [SerializeField]
    private GameObject objectInDrawer;

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

        //여기 있는 1줄이 추가됨
        objectInDrawer.GetComponent<Collider>().enabled = opened;

        SoundSystem.Instance.PlaySFX("Drawer", transform.position);
    }

    public void Unlock()
    {
        GameManager.Instance.Inventory.ClearItem();

        locked = false;

        SoundSystem.Instance.PlaySFX("LockUnlock", transform.position);
    }
}
