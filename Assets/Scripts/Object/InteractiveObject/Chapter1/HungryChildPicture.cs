using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryChildPicture : MonoBehaviour
{
    private ReactInteraction reactInteraction;

    private void Start()
    {
        reactInteraction = GetComponent<ReactInteraction>();
    }

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void FirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildInteract");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildAfterInteract");
    }

    public void UseApple()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildFirst");
    }

    public void RetryAfterUseApple()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildRetry");
    }

    public void GainPuzzlePaper()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
    }
}
