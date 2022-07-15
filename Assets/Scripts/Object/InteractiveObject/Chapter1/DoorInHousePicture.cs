public class DoorInHousePicture : InteractiveObject
{
    protected override void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER1_KEY)
        {
            if (clearInteract)
            {
                DialogueSystem.Instance.StartDialogue("DoorInHouseDaytimeAfterInteract");
            }
            else
            {
                clearInteract = true;
                DialogueSystem.Instance.StartDialogue("DoorInHouseDaytimeInteract");
            }
        }
        else if (!interactRetry)
        {
            interactRetry = true;
            DialogueSystem.Instance.StartDialogue("DoorInHouseDaytimeFirst");
        }
        else
        {
            DialogueSystem.Instance.StartDialogue("DoorInHouseDaytimeRetry");
        }
    }
}
