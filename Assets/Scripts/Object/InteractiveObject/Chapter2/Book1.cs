using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book1 : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_BOOK1);
        Destroy(gameObject);
    }
}
