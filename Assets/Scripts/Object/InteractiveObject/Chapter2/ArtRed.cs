using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtRed : MonoBehaviour
{
    private bool isChanged = false;

    public void Interact()
    {
        if(isChanged)
        {

        }
    }

    public void ChangeArt()
    {
        isChanged = true;

        // 그림 변화
    }
}
