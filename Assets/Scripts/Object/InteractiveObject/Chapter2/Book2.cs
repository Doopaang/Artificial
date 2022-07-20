using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book2 : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_BOOK2);
        Destroy(gameObject);
    }
}
