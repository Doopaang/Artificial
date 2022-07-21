using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Inventory inventory;

    public List<Item> itemDictionary;

    private bool isDaytime = true;

    [SerializeField]
    private HousePicture housePicture;


    [HideInInspector]
    public Color brushColor = Color.white;

    public bool IsDaytime
    {
        get
        {
            return isDaytime;
        }
        set
        {
            isDaytime = value;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeBrushColor(ref brushColor.r);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeBrushColor(ref brushColor.g);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeBrushColor(ref brushColor.b);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 v = new Vector3();
        //    v.x = Input.mousePosition.x / 1280.0f;
        //    v.y = Input.mousePosition.y / 720.0f;

        //    Ray ray = GameObject.Find("UI Camera").GetComponent<Camera>().ViewportPointToRay(v);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //        print("I'm looking at " + hit.transform.name);
        //    else
        //        print("I'm looking at nothing!");
        //}
    }

    public void ChangeToDaytime()
    {
        isDaytime = true;

        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Daytime);
    }

    public void ChangeToNight()
    {
        isDaytime = false;

        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Night);
    }

    public void ChangeBrushColor(ref float brush)
    {
        if (brush > 0)
        {
            brushColor = Color.black;
        }
        brush = 1.0f;
    }

    public void Chapter2Puzzle1Solved(Transform cover)
    {
        Destroy(cover.gameObject);
    }

    public void Chapter2Puzzle2Solved(Transform cover)
    {
        Destroy(cover.gameObject);
    }

    public void CHpater2Puzzle3Solved(Transform cover)
    {
        Destroy(cover.gameObject);
    }
}
