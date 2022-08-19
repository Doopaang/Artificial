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
        DialogueSystem.Instance.StartDialogue("First_Lady");
    }

    public void InvestigateRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Many_Times_Lady");
    }

    public void UseKey()
    {
        housePicture.UnlockGate();

        DialogueSystem.Instance.StartDialogue("Give_Key_Lady", OpenGate);
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_KEY);
    }

    private void OpenGate()
    {
        SoundSystem.Instance.PlaySFX("HouseDoor", transform.position);
        DialogueSystem.Instance.StartDialogue("Open_Gate", EnterHouse);
    }

    public void EnterHouse()
    {
        housePicture.ChangePicture(EHousePictureType.Inside);
    }
}
