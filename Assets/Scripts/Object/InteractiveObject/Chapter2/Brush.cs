using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    private void Start()
    {
        GetComponent<MeshRenderer>().materials[1].SetColor("_Color", GameManager.Instance.brushColor);
    }

    public void Interect()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        Destroy(gameObject);
    }

}
