using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    NONE,
    ITEM_1,
    ITEM_2,
    ITEM_3
}

[System.Serializable]
public struct ItemData
{
    public EItemType itemType;

    public EItemType combinableItemType;

    public EItemType combineResultItemType;

    public Sprite itemSprite;
}

public class Item : InteractiveObject
{
    [SerializeField]
    private EItemType itemType;

    protected override void Interact()
    {
        GameManager.Instance.inventory.GainItem(itemType);
        //gameObject.SetActive(false);
    }
}
