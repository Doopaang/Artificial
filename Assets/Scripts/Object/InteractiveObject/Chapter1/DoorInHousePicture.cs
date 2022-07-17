using UnityEngine;

public class DoorInHousePicture : InteractiveObject
{
    [SerializeField]
    private bool opened;

    protected override void Interact()
    {
        if (opened)
        {
            transform.parent.GetComponent<SwapableObject>().SwapObjectByIndex(4);
            DialogueSystem.Instance.StartDialogue("OpenDoorInHousePicture");
            return;
        }

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
