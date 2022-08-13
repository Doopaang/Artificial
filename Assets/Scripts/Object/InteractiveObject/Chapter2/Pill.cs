using UnityEngine;

public class Pill : MonoBehaviour
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

    public void SearchPill()
    {
        DialogueSystem.Instance.StartDialogue("Sleeping_Pills_Search_Without_Item");
    }

    public void UseHook()
    {
        DialogueSystem.Instance.StartDialogue("Use_Fishing_Rod", AfterUseHook);
    }

    public void AfterUseHook()
    {
        DialogueSystem.Instance.StartDialogue("After_Gain_Sleeping_Pills", GainPill);
    }

    public void GainPill()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_PILL);
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_HOOK);
        Destroy(gameObject);
    }
}
