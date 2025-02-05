using UnityEngine;

public enum PaintColor
{
    White, Red, Green, Blue, Black
}

public class Paint : MonoBehaviour
{
    [SerializeField]
    private PaintColor color;

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_BRUSH)
        {
            switch(color)
            {
                case PaintColor.Red:
                    GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.r);
                    break;

                case PaintColor.Green:
                    GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.g);
                    break;

                case PaintColor.Blue:
                    GameManager.Instance.ChangeBrushColor(ref GameManager.Instance.brushColor.b);
                    break;

                default:
                    throw new System.ArgumentException();
            }

            GameManager.Instance.Inventory.UsingItemUI.brushUI.UnlockButton(color);
            GameManager.Instance.brushUI.ApplyBrushColor();
        }
    }
}
