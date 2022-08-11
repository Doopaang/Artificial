using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullChildPicture : MonoBehaviour
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
        DialogueSystem.Instance.StartDialogue("After_Give_Apple", PrintGainEatenAppleText);
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("After_Gain_EatenApple");
    }

    public void PrintGainEatenAppleText()
    {
        DialogueSystem.Instance.StartDialogue("Gain_Eaten_Apple", GainEatenApple);
    }

    public void GainEatenApple()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
    }
}
