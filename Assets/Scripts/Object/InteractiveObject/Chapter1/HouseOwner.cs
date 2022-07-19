using UnityEngine;

public class HouseOwner : MonoBehaviour
{
    [SerializeField]
    private Gate gate;

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
        gate.Unlock();

        DialogueSystem.Instance.StartDialogue("OpenGate");
        gameObject.SetActive(false);
    }
}
