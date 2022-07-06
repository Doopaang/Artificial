using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EItemType
{
    NONE,
    ITEM_1
}

[System.Serializable]
public struct ItemData
{
    public EItemType ItemType;

    public Sprite sprite;
}

public class Inventory : MonoBehaviour
{
    public List<ItemData> itemDictionary;

    List<EItemType> curItemList;

    void Start()
    {
        itemDictionary = new List<ItemData>();
        curItemList = new List<EItemType>();
    }

    void Update()
    {
        
    }

}
