public class HouseOwner : InteractiveObject
{
    protected override void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER1_KEY)
        {
            clearInteract = true;
            DialogueSystem.Instance.StartDialogue("HouseOwnerInteract");
        }
        else if (clearInteract)
        {
            DialogueSystem.Instance.StartDialogue("HouseOwnerAfterInteract");
        }
        else if (!interactRetry)
        {
            interactRetry = true;
            DialogueSystem.Instance.StartDialogue("HouseOwnerFirst");
        }
        else
        {
            DialogueSystem.Instance.StartDialogue("HouseOwnerRetry");
        }
    }
}
