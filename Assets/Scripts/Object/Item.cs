using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    NONE,
    ITEM_1
}

public class Item : Object
{
    public Inventory inventory;

    public EItemType itemType;

    void Start()
    {

    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        inventory.GainItem(itemType);
        gameObject.SetActive(false);
    }
}
