using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzleObject : PuzzleObject
{
    [SerializeField]
    protected PuzzleColorSet colorSet;

    protected Color GetColor()
    {
        Color color = GameManager.Instance.brushColor;
        if (color == Color.red)
        {
            return colorSet.red;
        }
        else if (color == Color.green)
        {
            return colorSet.green;
        }
        else if (color == Color.blue)
        {
            return colorSet.blue;
        }
        else if (color == Color.cyan)
        {
            return colorSet.cyan;
        }
        else if (color == new Color(1, 1, 0))
        {
            return colorSet.yellow;
        }
        else if (color == Color.magenta)
        {
            return colorSet.magenta;
        }
        else if (color == Color.white)
        {
            return colorSet.white;
        }
        else
        {
            return colorSet.gray;
        }
    }
}
