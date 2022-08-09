using UnityEngine;

public class Book : MonoBehaviour
{
    [TextArea]
    public string text;

    public void Interact(int num)
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_BOOK1 + num - 1);
        Destroy(gameObject);
    }
}
