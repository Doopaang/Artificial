using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class LockNum : PuzzleObject
{
    [Header("LockNum")]
    [SerializeField]
    public int answer;
    [SerializeField]
    public int numLimit;
    [SerializeField]
    public int angleCount;
    [SerializeField]
    private Sprite leftButtonSprite;
    [SerializeField]
    private Sprite rightButtonSprite;
    [SerializeField]
    public List<Transform> dialList;

    [Space(20)]
    [Header("Lock Base")]
    [SerializeField]
    private Transform lockPos;
    [SerializeField]
    private GameObject buttonPrefab;
    private int pastNumLimit = 0;
    private int intParameter;

    [HideInInspector]
    public int value = 0;

    protected new void Start()
    {
        base.Start();

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
                Destroy(button.gameObject);
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

        LockButton lockBtn = newButton.GetComponent<LockButton>();
        lockBtn.value = (int)Mathf.Pow(10, num - 1) * (isRight ? 1 : -1);
        lockBtn.lockNum = this;
        lockBtn.solvedFunction = solvedFunction;

        newButton.name = (Mathf.Pow(10, num - 1) * (isRight ? 1 : -1)).ToString();
        image.sprite = isRight ? rightButtonSprite : leftButtonSprite;

        button.onClick.AddListener(lockBtn.ControlLock);

        //var targetinfo = UnityEventBase.GetValidMethodInfo(this, "ControlLock", new System.Type[] { typeof(int) });
        //int intParameter = (int)Mathf.Pow(10, num - 1) * (isRight ? 1 : -1);
        //UnityAction<int> action = System.Delegate.CreateDelegate(typeof(UnityAction<int>), this, targetinfo, false) as UnityAction<int>;
        //UnityEventTools.AddIntPersistentListener(button.onClick, action, intParameter);

        newButton.transform.SetAsFirstSibling();
    }

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
}
