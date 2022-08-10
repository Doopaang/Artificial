using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CursorSet", menuName = "CursorSet", order = 1)]
public class CursorSet : ScriptableObject
{
    public Texture2D cursorSprite;
    public Vector2 hitSpot;
}
