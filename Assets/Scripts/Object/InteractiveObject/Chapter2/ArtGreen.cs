using UnityEngine;

public class ArtGreen : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer greenRenderer;
    [SerializeField]
    private MeshRenderer whiteRenderer;

    [SerializeField]
    private ArtRed red;

    [SerializeField]
    private ArtYellow yellow;

    [HideInInspector]
    public bool isChanged = false;

    private bool isFirst = true;
    private bool isFlowerFirst = true;

    public void Interact()
    {
        if (isFirst)
        {
            isFirst = false;
            DialogueSystem.Instance.StartDialogue("Green_First");
        }
        else if (isFlowerFirst)
        {
            if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLOWER)
            {
                isFlowerFirst = false;
                GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_FLOWER);

                DialogueSystem.Instance.StartDialogue("Green_Use_Flower", GainGreenHandle);
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("Green_Many_Times");
            }
        }
        else
        {
            if (!yellow.isFirstGreen)
            {
                DialogueSystem.Instance.StartDialogue("Green_After_tell_to_yellow");
            }
            else if (isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Green_After_green_died");
            }
            else if (red.isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Green_After_red_died", ChangePicture);
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("Green_After_Use_Flower");
            }
        }
    }

    public void GainGreenHandle()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_GREEN);
    }

    private void ChangePicture()
    {
        isChanged = true;
        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(greenRenderer, whiteRenderer));

        DialogueSystem.Instance.StartDialogue("Green_After_effect");
    }
}
