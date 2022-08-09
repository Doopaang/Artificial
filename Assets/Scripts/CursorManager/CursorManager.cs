using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField]
    private CursorSet defaultCursor;
    [SerializeField]
    private CursorSet interactCursor;

    public enum ECursorType
    {
        DEFAULT, INTERACT
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SetCursor(ECursorType.DEFAULT);
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition)))
        {
            SetCursor(ECursorType.INTERACT);
            return;
        }
        SetCursor(ECursorType.DEFAULT);
    }

    public void SetCursor(ECursorType type)
    {
        CursorSet target;
        switch (type)
        {
            case ECursorType.DEFAULT:
                target = defaultCursor;
                break;

            case ECursorType.INTERACT:
                target = interactCursor;
                break;

            default:
                throw new System.ArgumentException();
        }
        Cursor.SetCursor(target.cursorSprite, target.hitSpot, CursorMode.Auto);
    }
}
