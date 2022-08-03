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
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        Destroy(gameObject);
    }

    public void ApplyColor()
    {
        GetComponent<MeshRenderer>().materials[1].SetColor("_Color", GameManager.Instance.brushColor);
    }

}
