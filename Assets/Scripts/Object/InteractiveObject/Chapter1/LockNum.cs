using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif

public class LockNum : PuzzleObject
{
    [Header("LockNum")]
    [SerializeField]
    private int answer;
    [SerializeField]
    private int numLimit;
    [SerializeField]
    private int angleCount;
#if UNITY_EDITOR
    [SerializeField]
    private Sprite leftButtonSprite;
    [SerializeField]
    private Sprite rightButtonSprite;
#endif
    [SerializeField]
    private List<Transform> dialList;

    [Space(20)]
    [Header("Lock Base")]
    [SerializeField]
    private Transform lockPos;
#if UNITY_EDITOR
    [SerializeField]
    private GameObject buttonPrefab;
    private int pastNumLimit = 0;
#endif

    private int value = 0;

#if UNITY_EDITOR

    protected override void _OnValidate()
    {
        base._OnValidate();

        InitButtons();
    }

    private void ClearChild()
    {
        if (lockPos == null)
        {
            return;
        }

        Button[] list = lockPos.GetComponentsInChildren<Button>();

        foreach (Button button in list)
        {
            if (button)
            {
                DestroyImmediate(button.gameObject);
            }
        }
    }

    private void AddChild(int i)
    {
        if (lockPos == null)
        {
            return;
        }

        bool isRight = (i + 1) % 2 != 0;
        int num = Mathf.CeilToInt((i + 1) * 0.5f);

        GameObject newButton = Instantiate(buttonPrefab, lockPos.transform);
        Button button = newButton.GetComponent<Button>();
        Image image = newButton.GetComponent<Image>();

        newButton.name = (isRight ? "Right" : "Left") + " Button " + num;
        image.sprite = isRight ? rightButtonSprite : leftButtonSprite;

        var targetinfo = UnityEventBase.GetValidMethodInfo(this, "ControlLock", new System.Type[] { typeof(int) });
        int intParameter = (int)Mathf.Pow(10, num - 1) * (isRight ? 1 : -1);
        UnityAction<int> action = System.Delegate.CreateDelegate(typeof(UnityAction<int>), this, targetinfo, false) as UnityAction<int>;
        UnityEventTools.AddIntPersistentListener(button.onClick, action, intParameter);

        newButton.transform.SetAsFirstSibling();
    }

#endif

    protected override void Start()
    {
        base.Start();

#if UNITY_EDITOR
        InitButtons();
#endif
    }

#if UNITY_EDITOR
    private void InitButtons()
    {
        if (numLimit == pastNumLimit)
        {
            return;
        }

        ClearChild();

        for (int i = 0; i < numLimit * 2; i++)
        {
            AddChild(i);
        }

        pastNumLimit = numLimit;
    }
#endif

    public void ControlLock(int value)
    {
        if (value == 0)
        {
            throw new System.ArgumentException();
        }

        int absValue = Mathf.Abs(value);
        bool isLeft = value < 0;

        this.value += value * (isLeft && this.value / absValue % 10 == 0 || !isLeft && this.value / absValue % 10 == 9 ? -9 : 1);

        Debug.Log(this.value);

        if (dialList.Count == numLimit)
        {
            Transform target = dialList[numLimit - (int)Mathf.Log10(absValue) - 1].transform;
            target.Rotate(target.up, 360.0f / angleCount * (isLeft ? -1 : 1));
        }

        if (this.value == answer)
        {
            solvedFunction.Invoke();
        }
    }
}
