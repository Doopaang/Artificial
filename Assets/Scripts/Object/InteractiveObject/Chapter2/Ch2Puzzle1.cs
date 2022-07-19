using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ch2Puzzle1 : PuzzleObject
{
    [Header("Ch2Puzzle1 Base")]
    [SerializeField]
    private Transform gridPos;

    private List<Toggle> toggleList;
    private List<Toggle> answerList;
    private int toggleIndex = 0;
    private bool correctOrder = true;

    protected override void Start()
    {
        base.Start();

        toggleList = new List<Toggle>(GetComponentsInChildren<Toggle>());
        toggleList.Sort((A, B) => { return int.Parse(A.name).CompareTo(int.Parse(B.name)); });

        answerList = new List<Toggle>(toggleList.FindAll((toggle) => { return toggle.isOn; }));

        ResetPad();
    }

    protected void OnEnable()
    {
        ResetPad();
    }

    public void ToggleButton(Toggle toggle)
    {
        toggle.interactable = false;

        if (toggleIndex >= answerList.Count ||
            toggle != answerList[toggleIndex])
        {
            correctOrder = false;
        }

        toggleIndex++;
    }

    public void CheckAnswer()
    {
        if (!correctOrder ||
            toggleIndex != answerList.Count)
        {
            ResetPad();
            return;
        }

        solvedFunction.Invoke();
    }

    private void ResetPad()
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
