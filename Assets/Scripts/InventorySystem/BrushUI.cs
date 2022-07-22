using UnityEngine;
using UnityEngine.UI;

public class BrushUI : MonoBehaviour
{
    [SerializeField]
    private Button red;
    [SerializeField]
    private Button green;
    [SerializeField]
    private Button blue;

    public void ClickButton(string color)
    {
        switch(color)
        {
            case "red":
                GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.r);
                break;

            case "green":
                GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.g);
                break;

            case "blue":
                GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.b);
                break;

            default:
                throw new System.ArgumentException();
        }
    }

    public void UnlockButton(PaintColor color)
    {
        switch (color)
        {
            case PaintColor.Red:
                red.interactable = true;
                break;

            case PaintColor.Green:
                green.interactable = true;
                break;

            case PaintColor.Blue:
                blue.interactable = true;
                break;

            default:
                throw new System.ArgumentException();
        }
    }
}
