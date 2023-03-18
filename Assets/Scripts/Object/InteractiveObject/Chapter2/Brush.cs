using UnityEngine;
using UnityEngine.SceneManagement;

public class Brush : MonoBehaviour
{
    private static bool interected = false;

    private bool sceneUnloading = false;

    private void Awake()
    {
        SceneManager.sceneUnloaded += CheckSceneUnload;
    }

    private void OnDestroy()
    {
        if (interected && !sceneUnloading)
        {
            GameManager.Instance.brushUI.Brushes.Remove(this);
        }
    }

    private void Start()
    {
        if (interected)
        {
            GameManager.Instance.brushUI.AddBrush(this);
        }
        ApplyColor();
    }

    public void Interect()
    {
        interected = true;
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        Destroy(gameObject);
        GameManager.Instance.saveData.SaveMapItem(this);
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

    private void CheckSceneUnload(Scene scene)
    {
        sceneUnloading = true;
    }
}
