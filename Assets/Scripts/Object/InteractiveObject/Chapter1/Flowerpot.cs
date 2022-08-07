using UnityEngine;

public class Flowerpot : MonoBehaviour
{
    [SerializeField]
    private bool hasKey;

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

    public void InvestigateFirst()
    {
        if (hasKey)
            DialogueSystem.Instance.StartDialogue("HasKeyFlowerpotFirst", GainKey);
        else
            DialogueSystem.Instance.StartDialogue("NotKeyFlowerpotFirst");
    }

    public void InvestigateRetry()
    {
        DialogueSystem.Instance.StartDialogue("NotKeyFlowerpotRetry");
    }

    public void GainKey()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_KEY);
    }
}
