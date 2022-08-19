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

    private List<Brush> brushes = new List<Brush>();

    public List<Brush> Brushes
    {
        get
        {
            return brushes;
        }
    }

    public void AddBrush(Brush brush)
    {
        brushes.Add(brush);
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
        foreach(Brush brush in brushes)
        {
            brush.ApplyColor();
        }
    }
}
