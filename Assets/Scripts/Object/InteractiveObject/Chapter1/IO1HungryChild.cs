public class IO1HungryChild : InteractiveObject
{
    protected override void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER1_APPLE)
        {
            clearInteract = true;
            DialogueSystem.Instance.StartDialogue("HungryChildInteract", GainItem);
        }
        else if (clearInteract)
        {
            DialogueSystem.Instance.StartDialogue("HungryChildAfterInteract");
        }
        else if (!interactRetry)
        {
            interactRetry = true;
            DialogueSystem.Instance.StartDialogue("HungryChildFirst");
        }
        else
        {
            DialogueSystem.Instance.StartDialogue("HungryChildRetry");
        }
    }

    private void GainItem()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
    }
}
