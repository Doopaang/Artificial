using UnityEngine;

public class Gate : MonoBehaviour
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
        if (!housePicture.GateLocked)
        {
            DialogueSystem.Instance.StartDialogue("EnterHouse", ChangeToHouseInsidePicture);
            return;
        }
        else if (!GameManager.Instance.IsDaytime)
        {
            DialogueSystem.Instance.StartDialogue("GateInteractNight");
            return;
        }

        if (reactInteraction)
            reactInteraction.React();
    }

    public void InvestigateFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("GateFirstNoneItem");
    }

    public void InvestigateRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("GateRetryNoneItem");
    }

    public void InvestigateFirstKey()
    {
        DialogueSystem.Instance.StartDialogue("GateFirstInteractKey");
    }

    public void InvestigateRetryKey()
    {
        DialogueSystem.Instance.StartDialogue("GateRetryInteractKey");
    }

    public void ChangeToHouseInsidePicture()
    {
        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Inside);

        DialogueSystem.Instance.StartDialogue("AfterEnterHouse");
    }
}
