using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IO1LockNum : InteractiveObject
{
    [SerializeField, Header("Puzzle")]
    private int answer;
#if UNITY_EDITOR
    [SerializeField]
    private int numLimit;
    [SerializeField]
    private Sprite leftButtonSprite;
    [SerializeField]
    private Sprite rightButtonSprite;
#endif
    [SerializeField]
    private UnityEvent solvedFunction;

    [SerializeField, Header("Base")]
    private Canvas canvas;
    [SerializeField]
    private Transform lockPos;
#if UNITY_EDITOR
    [SerializeField]
    private GameObject buttonPrefab;
    private int pastNumLimit = 0;
#endif

    private int value = 0;

#if UNITY_EDITOR

    private void OnValidate()
    {
        if (numLimit == pastNumLimit)
        {
            return;
        }

        UnityEditor.EditorApplication.delayCall += () =>
        {
            ClearChild();

            for (int i = 0; i < numLimit * 2; i++)
            {
                AddChild(i);
            }

            pastNumLimit = numLimit;
        };
    }

    private void ClearChild()
    {
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
        bool isLeft = (i + 1) % 2 != 0;
        int num = Mathf.CeilToInt((i + 1) * 0.5f);

        GameObject newButton = Instantiate(buttonPrefab, lockPos.transform);
        Button button = newButton.GetComponent<Button>();
        Image image = newButton.GetComponent<Image>();

        newButton.name = (isLeft ? "Right" : "Left") + " Button " + num;
        image.sprite = isLeft ? rightButtonSprite : leftButtonSprite;
        button.onClick.AddListener(delegate { ControlLock((int)Mathf.Pow(10, num - 1) * (isLeft ? 1 : -1)); });
        newButton.transform.SetAsFirstSibling();
    }

#endif

    protected override void Interact()
    {

    }

    public void ControlLock(int value)
    {
        if (value == 0)
        {
            throw new System.ArgumentException();
        }

        this.value += value * (value < 0 && this.value / Mathf.Abs(value) % 10 == 0 || value > 0 && this.value / Mathf.Abs(value) % 10 == 9 ? -9 : 1);

        Debug.Log(this.value);

        if (this.value == answer)
        {
            solvedFunction.Invoke();
        }
    }

    protected override void OnInteractableChanged(bool value)
    {
        canvas.gameObject.SetActive(value);
    }
}
