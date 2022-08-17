using UnityEngine;

public class Brush : MonoBehaviour
{
    private bool paint = false;

    private void Start()
    {
        GameManager.Instance.brushUI.AddBrush(this);

        SetPaintAlpha(0.0f);
    }

    public void Interect()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        Destroy(gameObject);
    }

    public void ApplyColor()
    {
        if (!paint)
        {
            paint = true;
            SetPaintAlpha(1.0f);
        }
    }

    private void SetPaintAlpha(float value)
    {
        Color color = GameManager.Instance.brushColor;
        color.a = value;
        GetComponentInChildren<MeshRenderer>().materials[0].SetColor("_Color", color);
    }
}
