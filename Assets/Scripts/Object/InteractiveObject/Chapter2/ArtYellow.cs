using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private ArtRed red;

    private bool isFirst = true;
    private bool usedFlower = false;
    private bool usedKnife = false;
    private bool usedPill = false;

    public void Interact()
    {
        switch (GameManager.Instance.Inventory.UsingItem)
        {
            case EItemType.CHAPTER2_KNIFE:
                DialogueSystem.Instance.StartDialogue("Yellow_Use_Knife", UseKnife);
                break;

            case EItemType.CHAPTER2_FLOWER:
                if (!usedFlower)
                {
                    usedFlower = true;
                    DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower");
                }
                else
                {
                    DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower_Many_Times");
                }
                break;

            default:
                if (!usedKnife)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        DialogueSystem.Instance.StartDialogue("Yellow_First");
                    }
                    else
                    {
                        DialogueSystem.Instance.StartDialogue("Yellow_Many_Times");
                    }
                }
                else
                {
                    DialogueSystem.Instance.StartDialogue("Yellow_After_Gain_Item");
                }
                break;
        }
    }

    private void UseKnife()
    {
        VisualSystem.Instance.StartBlackOut();
        /// [임시] 효과음 출력
        VisualSystem.Instance.StopBlackOut();
    }
}
