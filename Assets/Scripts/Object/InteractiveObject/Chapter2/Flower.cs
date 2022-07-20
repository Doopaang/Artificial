using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_FLOWER);
        Destroy(gameObject);
    }
}
