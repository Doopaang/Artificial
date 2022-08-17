using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorManager : Singleton<CursorManager>
{
    [SerializeField]
    private Camera UICamera;

    [SerializeField]
    private CursorSet defaultCursor;
    [SerializeField]
    private CursorSet interactCursor;

    private ECursorType current = ECursorType.DEFAULT;

    private GraphicRaycaster[] gr;

    public enum ECursorType
    {
        DEFAULT, INTERACT
    }

    private void Awake()
    {
        gr = FindObjectsOfType<GraphicRaycaster>();

        SetCursor(ECursorType.DEFAULT);
    }

    private void Update()
    {
        bool interact = false;

        RaycastHit hitObject;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObject) &&
            hitObject.transform.tag != "NotInteract")
        {
            interact = true;
        }

        List<RaycastResult> hitUI = new List<RaycastResult>();
        var ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        foreach (var a in gr)
        {
            hitUI.Clear();
            a.Raycast(ped, hitUI);

            if (hitUI.Count > 0 &&
                hitUI[0].gameObject.tag == "Interact")
            {
                interact = true;
                break;
            }
        }

        if(interact)
        {
            if (current == ECursorType.DEFAULT)
            {
                SetCursor(ECursorType.INTERACT);
                return;
            }
        }
        else
        {
            if (current == ECursorType.INTERACT)
            {
                SetCursor(ECursorType.DEFAULT);
                return;
            }
        }
    }

    public void SetCursor(ECursorType type)
    {
        current = type;

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
