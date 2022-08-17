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
    public Color brushColor;

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
        brushColor = Color.black;
        brushUI.gameObject.SetActive(false);

        SoundSystem.Instance.PlayBGM("InGame");
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            inventory.GainItem(EItemType.CHAPTER2_BRUSH);
            brushUI.UnlockButton(PaintColor.Red);
            brushUI.UnlockButton(PaintColor.Green);
            brushUI.UnlockButton(PaintColor.Blue);
        }
    }
#endif

    public void SetInputBlock(bool value)
    {
        if (CursorManager.Instance)
        {
            CursorManager.Instance.SetCursor(CursorManager.ECursorType.DEFAULT);
            CursorManager.Instance.enabled = !value;
        }

        inputBlock.gameObject.SetActive(value);
    }

    public IEnumerator ChangeFadeCoroutine(MeshRenderer before, MeshRenderer after, bool isFade = true)
    {
        before.gameObject.SetActive(true);
        after.gameObject.SetActive(true);
        foreach (var col in before.GetComponents<Collider>())
        {
            col.enabled = false;
        }
        foreach (var col in after.GetComponents<Collider>())
        {
            col.enabled = false;
        }

        before.material.renderQueue += 1;

        Color color = before.material.color;
        while (color.a > 0.0f)
        {
            color.a -= (isFade ? fadeSpeed * Time.fixedDeltaTime : 1.0f);
            before.material.color = color;
            yield return new WaitForFixedUpdate();
        }

        before.gameObject.SetActive(false);
        color.a = 1.0f;
        before.material.color = color;
        before.material.renderQueue -= 1;
        foreach (var col in before.GetComponents<Collider>())
        {
            col.enabled = true;
        }
        foreach (var col in after.GetComponents<Collider>())
        {
            col.enabled = true;
        }
    }

    public void ChangeToDaytime()
    {
        if (housePicture && !isDaytime)
            housePicture.ChangeToDay();

        if (werewolfPicture && !isDaytime)
            werewolfPicture.ChangeToDay();

        isDaytime = true;
    }

    public void ChangeToNight()
    {
        if (housePicture && isDaytime)
            housePicture.ChangeToNight();

        if (werewolfPicture && isDaytime)
            werewolfPicture.ChangeToNight();

        isDaytime = false;
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
}
