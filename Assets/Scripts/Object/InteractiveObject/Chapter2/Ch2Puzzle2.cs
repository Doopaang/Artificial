using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch2Puzzle2 : ColorPuzzleObject
{
    [Header("Ch2Puzzle1 Base")]
    [SerializeField]
    private Transform gridPos;

    private List<Button> buttonList;

    protected override void Start()
    {
        base.Start();

        buttonList = new List<Button>(gridPos.GetComponentsInChildren<Button>());

        ResetButton();
    }

    public void ClickButton(Button button)
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_BRUSH)
        {
            button.GetComponent<Image>().color = GetColor();
        }
    }

    public void CheckAnswer()
    {
        foreach (Button button in buttonList)
        {
            if (button.GetComponent<Image>().color != button.colors.disabledColor)
            {
                ResetButton();
                return;
            }
        }

        Destroy(gameObject);
        solvedFunction.Invoke();
    }

    private void ResetButton()
    {
        foreach (Button button in buttonList)
        {
            button.GetComponent<Image>().color = colorSet.gray;
        }
    }
}
