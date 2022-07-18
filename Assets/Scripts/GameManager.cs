using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Inventory inventory;

    public List<Item> itemDictionary;

    private int activatedUINum;

    void Start()
    {
        InitActivatedUINum();
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 v = new Vector3();
    //        v.x = Input.mousePosition.x / 1280.0f;
    //        v.y = Input.mousePosition.y / 720.0f;

    //        Ray ray = Camera.main.ViewportPointToRay(v);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //            print("I'm looking at " + hit.transform.name);
    //        else
    //            print("I'm looking at nothing!");
    //    }
    //}

    public void InitActivatedUINum()
    {
        activatedUINum = 0;
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
