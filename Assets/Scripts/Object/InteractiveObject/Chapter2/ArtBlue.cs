using UnityEngine;

public class ArtBlue : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    private bool usedItem = false;

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void BlueFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Blue_First");
    }

    public void BlueRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Blue_Many_Times");
    }

    public void BlueUseItem()
    {
        if (!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_BRUSH &&
            GameManager.Instance.brushColor == new Color(1.0f, 1.0f, 0.0f, 1.0f))
        {
            usedItem = true;
            DialogueSystem.Instance.StartDialogue("Blue_Use_Yellow_Brush", GainBlueHandle);
        }
    }

    public void BlueAfterUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Blue_After_Give_Drink");
    }

    public void GainBlueHandle()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_BLUE);
    }
}
