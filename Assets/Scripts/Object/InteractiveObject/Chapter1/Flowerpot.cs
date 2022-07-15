using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerpot : InteractiveObject
{
    [SerializeField]
    private bool hasKey;

    protected override void Interact()
    {
        if (hasKey)
        {
            if (!interactRetry)
            {
                interactRetry = true;
                DialogueSystem.Instance.StartDialogue("HasKeyFlowerpotFirst", GainItem);
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("HasKeyFlowerpotRetry");
            }
        }
        else
        {
            if (!interactRetry)
            {
                interactRetry = true;
                DialogueSystem.Instance.StartDialogue("NotKeyFlowerpotFirst");
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("NotKeyFlowerpotRetry");
            }
        }
    }

    public void GainItem()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_KEY);
    }
}
