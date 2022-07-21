using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ch2Puzzle3 : PuzzleObject
{
    [Header("Ch2Puzzle1 Base")]
    [SerializeField]
    private Transform gridPos;

    private List<Toggle> toggleList;
    private int toggleIndex = 0;
    private bool correctOrder = true;

    protected override void Start()
    {
        base.Start();

        toggleList = new List<Toggle>(gridPos.GetComponentsInChildren<Toggle>());
        toggleList.Sort((A, B) => { return int.Parse(A.name).CompareTo(int.Parse(B.name)); });

        ResetButton();
    }

    protected void OnEnable()
    {
        ResetButton();
    }

    public void ToggleButton(Toggle toggle)
    {
        toggle.interactable = false;

        if (toggle != toggleList[toggleIndex])
        {
            correctOrder = false;
        }

        toggleIndex++;
    }

    public void CheckAnswer()
    {
        if (!correctOrder ||
            toggleIndex != toggleList.Count)
        {
            ResetButton();
            return;
        }

        Destroy(gameObject);
        solvedFunction.Invoke();
    }

    private void ResetButton()
    {
        toggleIndex = 0;
        correctOrder = true;

        if (toggleList != null)
        {
            foreach (Toggle toggle in toggleList)
            {
                toggle.onValueChanged.SetPersistentListenerState(0, UnityEventCallState.Off);
                toggle.isOn = false;
                toggle.onValueChanged.SetPersistentListenerState(0, UnityEventCallState.RuntimeOnly);
                toggle.interactable = true;
            }
        }
    }
}
