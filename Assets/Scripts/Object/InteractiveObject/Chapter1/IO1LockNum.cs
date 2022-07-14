using UnityEngine;
using UnityEngine.Events;

public class IO1LockNum : InteractiveObject
{
    [SerializeField, Header("Puzzle")]
    private int answer;
    [SerializeField]
    private UnityEvent solvedFunction;

    [SerializeField, Header("Base")]
    private Canvas canvas;

    private int value = 0;

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

        if (this.value == answer)
        {
            solvedFunction.Invoke();
        }
    }

    protected override void OnInteractableChanged(bool value)
    {
        canvas.gameObject.SetActive(value);

        if(!value)
        {
            this.value = 0;
        }
    }
}
