using UnityEngine;

public class PaperArrow : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_PAPER_ARROW);
        Destroy(gameObject);
    }
}
