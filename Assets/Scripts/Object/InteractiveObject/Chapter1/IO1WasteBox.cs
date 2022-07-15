public class IO1WasteBox : InteractiveObject
{
    protected override void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER1_EATEN_APPLE)
        {
            clearInteract = true;

            DialogueSystem.Instance.StartDialogue("WasteBasketInteract", GainItem);
        }
        else if (clearInteract)
        {
            DialogueSystem.Instance.StartDialogue("WasteBasketAfterInteract");
        }
        else if (interactCount++ <= 0)
        {
            DialogueSystem.Instance.StartDialogue("WasteBasketFirst");
        }
        else
        {
            DialogueSystem.Instance.StartDialogue("WasteBasketRetry");
        }
    }

    private void GainItem()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_EATEN_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_PAPER);
    }
}
