using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Inventory inventory;

    public BrushUI brushUI;

    public List<Item> itemDictionary;

    private bool isDaytime = true;

    [SerializeField]
    private HousePicture housePicture;

    [SerializeField]
    private WerewolfPicture werewolfPicture;

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

    private void Start()
    {
        //brushUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        }
    }

    public void ChangeToDaytime()
    {
        isDaytime = true;

        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Daytime);

        if (werewolfPicture)
            werewolfPicture.ChangePicture(EWerewolfPictureType.Daytime);
    }

    public void ChangeToNight()
    {
        isDaytime = false;

        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.Night);

        if (werewolfPicture)
            werewolfPicture.ChangePicture(EWerewolfPictureType.Night);
    }

    public void ChangeBrushColor(ref float brush)
    {
        if (brush > 0)
        {
            brushColor = Color.black;
        }

        brush = 1.0f;

        brushUI.ApplyBrushColor();
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
