using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    [SerializeField]
    private ArtRed red;

    private bool firstInteractFlower = true;

    public void Interact()
    {
        //if(!usedItem &&
        //    GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KNIFE)
        //{
        //    GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
        //    usedItem = true;

        //    red.ChangeArt();

        //    GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        //}

    }

    public void YellowFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_First");
    }

    public void YellowRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Many_Times");
    }

    public void YellowUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Knife");
    }

    public void YellowAfterUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_After_Gain_Item");
    }

    public void YellowFirstUseFlower()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower");
    }

    public void YellowRetryUseFlower()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower_Many_Times");
    }
}
