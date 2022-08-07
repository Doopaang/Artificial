using UnityEngine;

public class HouseOwner : MonoBehaviour
{
    [SerializeField]
    private HousePicture housePicture;

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

    public void InvestigateFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("HouseOwnerFirst");
    }

    public void InvestigateRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("HouseOwnerRetry");
    }

    public void UseKey()
    {
        housePicture.UnlockGate();

        DialogueSystem.Instance.StartDialogue("OpenGate");
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_KEY);
        housePicture.ChangePicture(EHousePictureType.Inside);
    }
}
