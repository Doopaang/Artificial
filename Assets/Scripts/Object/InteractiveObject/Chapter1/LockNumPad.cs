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

    [SerializeField]
    private TMPro.TextMeshProUGUI[] colorNum;

    private int value = 0;

    protected void OnEnable()
    {
        value = 0;
        text.text = "";
    }

    public void InputNum(int value)
    {

        if (numLimit == 0 ||
            this.value >= Mathf.Pow(10, numLimit - 1))
        {
            SoundSystem.Instance.PlaySFX("PasswordFailed", transform.parent.position);

            return;
        }

        SoundSystem.Instance.PlaySFX("PasswordPress", transform.parent.position);

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
        SoundSystem.Instance.PlaySFX("PasswordPress", transform.parent.position);

        value = (int)(value * 0.1f);

        UpdateText();
    }

    private void UpdateText()
    {
        text.text = value == 0 ? "" : value.ToString();

        for (int i = 0; i < colorNum.Length; i++)
        {
            if (i < text.text.Length)
                colorNum[i].text = text.text[i].ToString();
            else
                colorNum[i].text = "";
        }
    }
}
