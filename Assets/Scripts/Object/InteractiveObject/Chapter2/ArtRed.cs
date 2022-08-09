using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtRed : MonoBehaviour
{
    [SerializeField]
    private Transform movePos;

    private bool isChanged = false;

    public void Interact()
    {
        if(isChanged)
        {
            transform.SetPositionAndRotation(movePos.position, movePos.rotation);
        }
    }

    public void ChangeArt()
    {
        isChanged = true;
    }
}
