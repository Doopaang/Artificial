using UnityEngine;

public class Brush : MonoBehaviour
{
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
        GetComponentInChildren<MeshRenderer>().materials[0].SetColor("_Color", GameManager.Instance.brushColor);
    }
}
