using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryChildPicture : MonoBehaviour
{
    private ReactInteraction reactInteraction;

    [SerializeField]
    private ChildPicture childPicture;

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
        DialogueSystem.Instance.StartDialogue("HungryChildFirst");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildRetry");
    }

    public void UseApple()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildInteract", GainEatenApple);
    }

    public void RetryAfterUseApple()
    {
        DialogueSystem.Instance.StartDialogue("HungryChildAfterInteract");
    }

    public void GainEatenApple()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);

        childPicture.ChangeToFullChildPicture();
    }
}
