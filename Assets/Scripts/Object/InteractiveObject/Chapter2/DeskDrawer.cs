using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskDrawer : MonoBehaviour
{
    [SerializeField]
    private Transform drawer;
    [SerializeField]
    private Transform openPos;

    private bool isOpen = false;

    public void Interact()
    {
        if(isOpen)
        {

        }
        else
        {
            isOpen = true;

            drawer.position = openPos.position;
        }
    }
}
