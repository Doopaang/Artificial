using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_ROPE);
        Destroy(gameObject);
    }
}
