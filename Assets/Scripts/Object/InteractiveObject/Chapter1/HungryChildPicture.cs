using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryChildPicture : MonoBehaviour
{
    [SerializeField]
    private ChildPicture childPicture;

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

    public void FirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Hungry_Child_First");
    }

    public void RetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Hungry_Child_Many_Times");
    }

    public void UseApple()
    {
        DialogueSystem.Instance.StartDialogue("Give_Apple", ChangePicture);
    }

    public void ChangePicture()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER1_APPLE);

        childPicture.ChangeToFullChildPicture();
    }

    
}
