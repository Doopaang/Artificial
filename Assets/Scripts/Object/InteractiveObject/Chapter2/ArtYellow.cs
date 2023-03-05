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
    private MeshRenderer YellowPortrait;
    [SerializeField]
    private MeshRenderer WhitePortrait;
    [SerializeField]
    private ArtRed red;
    [SerializeField]
    private ArtGreen green;

    [HideInInspector]
    public bool isFirst = true;
    [HideInInspector]
    public bool usedFlower = false;
    [HideInInspector]
    public bool usedKnife = false;
    [HideInInspector]
    public bool isFirstGreen = true;

    [HideInInspector]
    public bool isChanged = false;

    public void Interact()
    {
        if (isFirst)
        {
            isFirst = false;
            DialogueSystem.Instance.StartDialogue("Yellow_First");
        }
        else if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KNIFE)
        {
            usedKnife = true;
            DialogueSystem.Instance.StartDialogue("Yellow_Use_Knife", UseKnife);
        }
        else if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLOWER)
        {
            if (!usedFlower)
            {
                usedFlower = true;
                DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower");
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower_Many_Times");
            }
        }
        else if (!usedKnife)
        {
            DialogueSystem.Instance.StartDialogue("Yellow_Many_Times");
        }
        else if (green.isChanged)
        {
            if (isFirstGreen)
            {
                isFirstGreen = false;
                DialogueSystem.Instance.StartDialogue("Yellow_After_green_died");
            }
            else if (isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Yellow_After_yellow_died");
            }
            else if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_PILL)
            {
                DialogueSystem.Instance.StartDialogue("Yellow_Use_sleeping_pills", GainHandle);
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

    private void UseKnife()
    {
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
        StartCoroutine(BlackOutCoroutine());
    }

    private IEnumerator BlackOutCoroutine()
    {
        VisualSystem.Instance.StartBlackOut();

        yield return new WaitForSeconds(soundBeforeDelay);

        red.ChangeArt();
        SoundSystem.Instance.PlaySFX("KnifeAttack", transform.position);

        yield return new WaitForSeconds(soundAfterDelay);

        VisualSystem.Instance.StopBlackOut();

        DialogueSystem.Instance.StartDialogue("Yellow_After_Effect", GainRedKey);
    }

    private void GainRedKey()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED, BlackOut2);
    }

    private void BlackOut2()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_After_Gain_Item");
    }

    private void GainHandle()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_YELLOW, GainHandleDialouge);
    }

    private void GainHandleDialouge()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_After_gain_black_handle", ChangePicture);
    }

    public void ChangePicture()
    {
        isChanged = true;
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_PILL);
        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(YellowPortrait, WhitePortrait));

        DialogueSystem.Instance.StartDialogue("Yellow_After_yellow_died_effect");
    }

    public void ChangePictureLoad()
    {
        isChanged = true;
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_PILL);
        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(YellowPortrait, WhitePortrait));
    }
}
