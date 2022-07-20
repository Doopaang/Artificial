using UnityEngine;

public class LockNumPad : PuzzleObject
{
    [Header("NumPad")]
    [SerializeField]
    private int answer;
    [SerializeField]
    private int numLimit;

    [Space(20)]
    [Header("NumPad Base")]
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    private int value = 0;

    public void InputNum(int value)
    {
        if (numLimit == 0 ||
            this.value >= Mathf.Pow(10, numLimit - 1))
        {
            return;
        }

        this.value *= 10;
        this.value += value;

        UpdateText();

        if (this.value == answer)
        {
            Destroy(gameObject);
            solvedFunction.Invoke();
        }
    }

    public void DelNum()
    {
        value = (int)(value * 0.1f);

        UpdateText();
    }

    private void UpdateText()
    {
        text.text = value == 0 ? "" : value.ToString();
    }
}
