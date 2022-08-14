using UnityEngine;

public class ArtRed : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    [SerializeField]
    private GameObject ShreddedRedCharacterPicture;

    [HideInInspector]
    public bool isChanged = false;

    public void Interact()
    {
        if (reactInteraction)
            reactInteraction.React();
    }

    public void ChangeArt()
    {
        isChanged = true;

        gameObject.SetActive(false);
        ShreddedRedCharacterPicture.SetActive(true);
    }

    public void RedFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Red_First");
    }

    public void RedRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Red_Many_Times");
    }
}
