using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp1 : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_TEMP1);
        Destroy(gameObject);
    }
}
