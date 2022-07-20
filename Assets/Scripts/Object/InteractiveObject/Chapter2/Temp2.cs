using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp2 : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_TEMP2);
        Destroy(gameObject);
    }
}
