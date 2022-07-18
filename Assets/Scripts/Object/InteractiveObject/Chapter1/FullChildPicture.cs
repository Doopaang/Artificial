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
        DialogueSystem.Instance.StartDialogue("FullChildFirst");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("FullChildRetry");
    }
}
