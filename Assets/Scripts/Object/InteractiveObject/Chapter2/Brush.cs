using UnityEngine;

public class Brush : MonoBehaviour
{
    private void OnDestroy()
    {
        if (GameManager.Instance &&
            GameManager.Instance.brushUI)
        {
            GameManager.Instance.brushUI.Brushes.Remove(this);
        }
    }

    private void Start()
    {
        GameManager.Instance.brushUI.AddBrush(this);

        ApplyColor();
    }

    public void Interect()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        Destroy(gameObject);
    }

    public void ApplyColor()
    {
        SetPaintAlpha(GameManager.Instance.brushColor == Color.black ? 0.0f : 1.0f);
    }

    private void SetPaintAlpha(float value)
    {
        Color color = GameManager.Instance.brushColor;
        color.a = value;
        GetComponentInChildren<MeshRenderer>().materials[0].SetColor("_Color", color);
    }
}
