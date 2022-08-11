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
        DialogueSystem.Instance.StartDialogue("Give_Key_MainDoor_Many_Times");
    }

    public void ChangeToHouseInsidePicture()
    {
        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Inside);

        DialogueSystem.Instance.StartDialogue("AfterEnterHouse");
    }
}
