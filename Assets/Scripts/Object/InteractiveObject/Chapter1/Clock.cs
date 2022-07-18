using UnityEngine;

public class Clock : MonoBehaviour
{
    public void Interact()
    {
        DialogueSystem.Instance.StartDialogue("ClockInteract", GainClock);
    }

    public void GainClock()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EMPTY_WATCH);
        gameObject.SetActive(false);
    }
}
