using UnityEngine;

public class Book : MonoBehaviour
{
    [TextArea]
    public string text;

    private bool first = true;

    private int bookNum;

    public void Interact(int num)
    {
        bookNum = num;

        if (first)
        {
            first = false;

            DialogueSystem.Instance.StartDialogue("Gain_First_Book", GainBook);
            return;
        }

        GainBook();
    }

    public void GainBook()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_BOOK1 + bookNum - 1);
        Destroy(gameObject);
    }
}
