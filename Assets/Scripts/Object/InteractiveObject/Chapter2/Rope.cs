using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField]
    private bool interactive = false;

    public void Interact()
    {
        if (interactive)
        {
            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_ROPE);
            Destroy(gameObject);
        }
    }

    public void EnableInteractive()
    {
        interactive = true;
    }
}
