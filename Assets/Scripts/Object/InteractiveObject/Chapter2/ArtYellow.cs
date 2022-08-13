using System.Collections;
using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private float soundBeforeDelay;
    [SerializeField]
    private float soundAfterDelay;

    [Space(3)]
    [SerializeField]
    private ArtRed red;
    [SerializeField]
    private ArtGreen green;

    private bool isFirst = true;
    private bool usedFlower = false;
    private bool usedKnife = false;
    private bool usedPill = false;
    private bool isFirstGreen = true;

    public void Interact()
    {
        switch (GameManager.Instance.Inventory.UsingItem)
        {
            case EItemType.CHAPTER2_KNIFE:
                usedKnife = true;
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
                    if (green.isChanged)
                    {
                        if (isFirstGreen)
                        {
                            DialogueSystem.Instance.StartDialogue("Yellow_After_green_died");
                        }
                        else
                        {
                            DialogueSystem.Instance.StartDialogue("Yellow_After_green_died_many_times");
                        }
                    }
                    else if (red.isChanged)
                    {
                        DialogueSystem.Instance.StartDialogue("Yellow_After_red_died");
                    }
                }
                break;
        }
    }

    private void UseKnife()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
        StartCoroutine(BlackOutCoroutine());
    }

    private IEnumerator BlackOutCoroutine()
    {
        VisualSystem.Instance.StartBlackOut();

        yield return new WaitForSeconds(soundBeforeDelay);

        /// [임시] 효과음 출력
        red.ChangeArt();

        yield return new WaitForSeconds(soundAfterDelay);

        VisualSystem.Instance.StopBlackOut();

        DialogueSystem.Instance.StartDialogue("Yellow_After_Effect", BlackOut2);
    }

    private void BlackOut2()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_After_Gain_Item", GainRedKey);
    }

    private void GainRedKey()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
    }
}
