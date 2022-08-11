using UnityEngine;

public class Werewolf : MonoBehaviour
{
    private ReactInteraction reactInteraction;

    [SerializeField]
    private WerewolfPicture werewolfPicture;

    [SerializeField]
    private Collider crescentMoonCollider;

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
        {
            DialogueSystem.Instance.StartDialogue("First_Morning");
        }
        else
        {
            DialogueSystem.Instance.StartDialogue("Many_Times_Night");
        }
    }

    public void InvestigateRetry()
    {
        if (GameManager.Instance.IsDaytime)
            DialogueSystem.Instance.StartDialogue("Many_Times_Morning");
        else
            DialogueSystem.Instance.StartDialogue("Many_Times_Night");
    }
}
