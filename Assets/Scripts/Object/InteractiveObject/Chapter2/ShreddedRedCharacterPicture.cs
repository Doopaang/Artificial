using UnityEngine;

public class ShreddedRedCharacterPicture : MonoBehaviour
{
    [SerializeField]
    private ArtGreen green;

    [HideInInspector]
    public bool isFirst = true;

    public void Interact()
    {
        if (isFirst)
        {
            isFirst = false;
            DialogueSystem.Instance.StartDialogue("Red_After_Red_Died");
        }
        else
        {
            if (green.isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Red_After_Green_Died");
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("Red_After_Red_Died_Many_Times");
            }
        }
    }
}
