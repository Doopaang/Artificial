using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Inventory inventory;

    private int activatedUINum;

    void Start()
    {
        activatedUINum = 0;
    }

    public bool EnableClickObject
    {
        get
        {
            return activatedUINum <= 0;
        }
    }

    public void IncreaseActivatedUINum()
    {
        activatedUINum++;
    }

    public void DecreaseActivatedUINum()
    {
        activatedUINum--;
    }

}
