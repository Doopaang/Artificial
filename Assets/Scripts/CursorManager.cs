using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField]
    private Texture2D defaultSprite;
    [SerializeField]
    private Texture2D interactSprite;

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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray))
        {
            SetCursor(ECursorType.INTERACT);
            return;
        }
        SetCursor(ECursorType.DEFAULT);
    }

    public void SetCursor(ECursorType type)
    {
        Texture2D target;
        switch (type)
        {
            case ECursorType.DEFAULT:
                target = defaultSprite;
                break;

            case ECursorType.INTERACT:
                target = interactSprite;
                break;

            default:
                throw new System.ArgumentException();
        }
        Cursor.SetCursor(target, new Vector2(10.0f, 6.0f), CursorMode.Auto);
    }
}
