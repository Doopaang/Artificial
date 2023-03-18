using UnityEngine;

public class ArtBlue : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer blueRenderer;
    [SerializeField]
    private MeshRenderer lemonRenderer;
    [SerializeField]
    private MeshRenderer whiteRenderer;

    [SerializeField]
    private GameObject cup;
    [SerializeField]
    private Color iteractiveColor;

    [SerializeField]
    private ArtRed red;
    [SerializeField]
    private ArtYellow yellow;

    [HideInInspector]
    public bool isChanged = false;

    [HideInInspector]
    public bool isFirst = true;
    [HideInInspector]
    public bool usedItem = false;

    public void Interact()
    {
        if (isFirst)
        {
            isFirst = false;
            cup.SetActive(true);
            DialogueSystem.Instance.StartDialogue("Blue_First");
        }
        else
        {
            if (isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Blue_After_Blue_Died");
            }
            else if (yellow.isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Blue_After_Yellow_Died", ChangeWhite);
            }
            else if (red.isChanged)
            {
                DialogueSystem.Instance.StartDialogue("Blue_After_red_died");
            }
            else if (usedItem)
            {
                DialogueSystem.Instance.StartDialogue("Blue_After_Give_Drink");
            }
            else
            {
                DialogueSystem.Instance.StartDialogue("Blue_Many_Times");
            }
        }
    }

    public void InteractCup()
    {
        if (!usedItem &&
            GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_BRUSH &&
            GameManager.Instance.brushColor == new Color(1.0f, 1.0f, 0.0f, 1.0f))
        {
            usedItem = true;
            cup.SetActive(false);
            DialogueSystem.Instance.StartDialogue("Blue_Use_Yellow_Brush", UseYellowBrush);
        }
    }

    private void UseYellowBrush()
    {
        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(blueRenderer, lemonRenderer));
        DialogueSystem.Instance.StartDialogue("Blue_Give_Drink", GainBlueHandle);
    }

    private void GainBlueHandle()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_BLUE, GainHandleAfter);
    }

    private void GainHandleAfter()
    {
        DialogueSystem.Instance.StartDialogue("After_Gain_Blue_Handle");
    }

    private void ChangeWhite()
    {
        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(lemonRenderer, whiteRenderer));
        DialogueSystem.Instance.StartDialogue("Blue_After_Effect");
        isChanged = true;
    }
    public void ChangePictureLoad()
    {
        if (isChanged)
        {
            cup.SetActive(false);
            blueRenderer.gameObject.SetActive(false);
            StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(lemonRenderer, whiteRenderer, false));
        }
        else if (usedItem)
        {
            cup.SetActive(false);
            StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(blueRenderer, lemonRenderer, false));
        }
    }
}
