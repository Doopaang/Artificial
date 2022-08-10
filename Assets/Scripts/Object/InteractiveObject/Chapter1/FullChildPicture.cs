using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullChildPicture : MonoBehaviour
{
    [SerializeField]
    private ChildPicture childPicture;

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
        DialogueSystem.Instance.StartDialogue("After_Give_Apple", GainEatenApple);
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Gain_Eaten_Apple");
    }

    public void GainEatenApple()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);

        childPicture.ChangeToFullChildPicture();
    }
}
