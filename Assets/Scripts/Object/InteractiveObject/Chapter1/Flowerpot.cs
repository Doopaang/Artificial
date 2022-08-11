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
            DialogueSystem.Instance.StartDialogue("Search_Flowerpot_Right", PrintGainKeyText);
        else
            DialogueSystem.Instance.StartDialogue("Search_Flowerpot_Left");
    }

    public void InvestigateRetry()
    {
        if (hasKey)
            DialogueSystem.Instance.StartDialogue("After_Gain_Key");
        else
            DialogueSystem.Instance.StartDialogue("Search_Flowerpot_Left");
    }

    public void PrintGainKeyText()
    {
        DialogueSystem.Instance.StartDialogue("Gain_Key", GainKey);
    }

    public void GainKey()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_KEY);
    }
}
