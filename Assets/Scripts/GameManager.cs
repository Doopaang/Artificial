using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Inventory inventory;

    public List<Item> itemDictionary;
}
