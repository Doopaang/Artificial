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
        DialogueSystem.Instance.StartDialogue("WasteBasketFirst");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("WasteBasketRetry");
    }

    public void UseEatenApple()
    {
        DialogueSystem.Instance.StartDialogue("WasteBasketInteract", GainPuzzlePaper);
    }

    public void RetryAfterUseEatenApple()
    {
        DialogueSystem.Instance.StartDialogue("WasteBasketAfterInteract");
    }

    public void GainPuzzlePaper()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_EATEN_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_OPEN_PUZZLE_PAPER);
    }
}
