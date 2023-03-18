using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private HousePicture housePicture;

    private ReactInteraction reactInteraction;

    private void Awake()
    {
        reactInteraction = GetComponent<ReactInteraction>();
    }

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void InvestigateFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("First_MainDoor");
    }

    public void InvestigateRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Many_Times_MainDoor");
    }

    public void InvestigateFirstKey()
    {
        DialogueSystem.Instance.StartDialogue("Give_Key_MainDoor");
    }

    public void InvestigateRetryKey()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER1_KEY)
            DialogueSystem.Instance.StartDialogue("Give_Key_MainDoor_Many_Times");
        else
            DialogueSystem.Instance.StartDialogue("Many_Times_MainDoor");
    }
}
