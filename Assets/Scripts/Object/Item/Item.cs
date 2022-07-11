using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    NONE,
    APPLE,
    EATEN_APPLE,
    SWAP_PUZZLE_PAPER,
    BATTERY, 
    BATTERY_WATCH,
    BATTERY_FREE_WATCH,
    KEY,
    CRESCENT_MOON,
    BRUSH
}

[System.Serializable]
public struct ItemData
{
    public EItemType itemType;

    public EItemType combinableItemType;

    public EItemType combineResultItemType;

    public Sprite itemSprite;

    public Mesh itemMesh;
}

public class Item : InteractiveObject
{
    protected override void Interact()
    {
        base.Interact();

        gameObject.SetActive(false);
    }
}
