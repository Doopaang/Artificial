using System.Collections;
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

    [SerializeField]
    private float fadeSpeed;

    [HideInInspector]
    public Color brushColor = Color.white;

    public BrushUI brushUI;

    [SerializeField]
    private Canvas inputBlock;

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

    public void SetInputBlock(bool value)
    {
        if (CursorManager.Instance)
        {
            CursorManager.Instance.SetCursor(CursorManager.ECursorType.DEFAULT);
            CursorManager.Instance.enabled = !value;
        }

        inputBlock.gameObject.SetActive(value);
    }

    public IEnumerator FadeCoroutine(MeshRenderer renderer, bool isIn, bool isFade = true)
    {
        renderer.gameObject.SetActive(true);

        Color color = renderer.material.color;
        color.a = isIn ? 0.0f : 1.0f;
        renderer.material.color = color;

        while (isIn && color.a < 1.0f ||
            !isIn && color.a > 0.0f)
        {
            color.a += (isFade ? fadeSpeed * Time.fixedDeltaTime : 1.0f) * (isIn ? 1.0f : -1.0f);
            renderer.material.color = color;
            yield return new WaitForFixedUpdate();
        }

        if (!isIn)
        {
            renderer.gameObject.SetActive(false);
        }
        color.a = 1.0f;
        renderer.material.color = color;
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
