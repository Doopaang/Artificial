public class HouseOwner : InteractiveObject
{
    protected override void Interact()
    {
        if (!clearInteract && GameManager.Instance.inventory.UsingItem == EItemType.NONE)
        {
            clearInteract = true;
            DialogueSystem.Instance.StartDialogue("HouseOwnerInteract");

            transform.parent.GetComponent<SwapableObject>().SwapObjectByIndex(3);
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
