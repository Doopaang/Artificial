using UnityEngine;

public class ArtGreen : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    private bool usedItem = false;

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void GreenFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Green_First");
    }

    public void GreenRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Green_Many_Times");
    }

    public void GreenUseItem()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_FLOWER);

        DialogueSystem.Instance.StartDialogue("Green_Use_Flower", GainGreenHandle);
    }

    public void GreenAfterUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Green_After_Use_Flower");
    }

    public void GainGreenHandle()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_GREEN);
    }
}
