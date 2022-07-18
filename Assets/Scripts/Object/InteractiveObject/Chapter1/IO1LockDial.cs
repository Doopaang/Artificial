using UnityEngine;
using UnityEngine.Events;

public class IO1LockDial : MonoBehaviour
{
    [SerializeField, Header("Puzzle")]
    private int answer;
    [SerializeField]
    private int numLimit;
    [SerializeField]
    private UnityEvent solvedFunction;

    [SerializeField, Header("Base")]
    private Canvas canvas;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    private int value = 0;

    protected void Interact()
    {

    }

    public void InputNum(int value)
    {
        if (this.value > Mathf.Pow(10, numLimit - 1))
        {
            return;
        }

        this.value *= 10;
        this.value += value;

        UpdateText();

        if (this.value == answer)
        {
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
