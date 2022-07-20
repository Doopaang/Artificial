using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperArrow : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER2_PAPER_ARROW);
        Destroy(gameObject);
    }
}
