using UnityEngine;

public class WasteBasket : MonoBehaviour
{
    private ReactInteraction reactInteraction;

    private void Awake()
    {
        reactInteraction = GetComponent<ReactInteraction>();
    }

    public void Interact()
    {
        reactInteraction.React();
    }

    public void FirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Trash_Can_First");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Trash_Can_Many_Times");
    }

    public void UseEatenApple()
    {
        DialogueSystem.Instance.StartDialogue("Give_EatenApple", GiveEatenApple);
    }

    public void RetryAfterUseEatenApple()
    {
        DialogueSystem.Instance.StartDialogue("Trash_Can_After_Gain_Hintpaper");
    }

    public void GiveEatenApple()
    {
        DialogueSystem.Instance.StartDialogue("Trash_Can_Gain_Hintpaper", GainHintPaper);
    }

    public void GainHintPaper()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_EATEN_APPLE);
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_OPEN_PUZZLE_PAPER);
    }
}
