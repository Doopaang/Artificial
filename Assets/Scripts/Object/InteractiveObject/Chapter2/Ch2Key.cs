using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch2Key : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_KEY);
        Destroy(gameObject);
    }
}
