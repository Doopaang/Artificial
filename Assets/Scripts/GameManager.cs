using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private HousePicture housePicture;

    [SerializeField]
    private WerewolfPicture werewolfPicture;

    [HideInInspector]
    public Color brushColor = Color.white;

    public BrushUI brushUI;

    public List<Item> itemDictionary;

    private bool isDaytime = true;

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

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }
    }

    private void Start()
    {
        brushUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            inventory.GainItem(EItemType.CHAPTER2_BRUSH);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DialogueSystem.Instance.StartDialogue("Test1");
        }
    }

    public void ChangeToDaytime()
    {
        isDaytime = true;

        if (housePicture)
            housePicture.ChangeToDay();

        if (werewolfPicture)
            werewolfPicture.ChangeToDay();
    }

    public void ChangeToNight()
    {
        isDaytime = false;

        if (housePicture)
            housePicture.ChangeToNight();

        if (werewolfPicture)
            werewolfPicture.ChangeToNight();
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
