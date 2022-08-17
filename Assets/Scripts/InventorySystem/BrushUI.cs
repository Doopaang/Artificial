using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BrushUI : MonoBehaviour
{
    [SerializeField]
    private Button red;

    [SerializeField]
    private Button green;

    [SerializeField]
    private Button blue;

    private Brush brush;

    public void AddBrush(Brush brush)
    {
        this.brush = brush;
    }

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

    public void ApplyBrushColor()
    {
        brush.ApplyColor();
    }
}
