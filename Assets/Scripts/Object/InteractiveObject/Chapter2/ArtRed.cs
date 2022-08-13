using UnityEngine;

public class ArtRed : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    [SerializeField]
    private Transform movePos;

    [SerializeField]
    public bool isChanged = false;

    public void Interact()
    {
        //if(isChanged)
        //{
        //    transform.SetPositionAndRotation(movePos.position, movePos.rotation);
        //}

        if (reactInteraction)
            reactInteraction.React();
    }

    public void ChangeArt()
    {
        isChanged = true;
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
