using UnityEngine;

public class Werewolf : MonoBehaviour
{
    private ReactInteraction reactInteraction;

    [SerializeField]
    private WerewolfPicture werewolfPicture;

    private void Start()
    {
        reactInteraction = GetComponentInChildren<ReactInteraction>();
    }

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void InvestigateFirst()
    {
        if (GameManager.Instance.IsDaytime)
            DialogueSystem.Instance.StartDialogue("WerewolfDaytimeFirst");
        else
            DialogueSystem.Instance.StartDialogue("WerewolfNightFirst");
    }

    public void InvestigateRetry()
    {
        if (GameManager.Instance.IsDaytime)
            DialogueSystem.Instance.StartDialogue("WerewolfDaytimeRetry");
        else
            DialogueSystem.Instance.StartDialogue("WerewolfNightRetry");
    }
}
