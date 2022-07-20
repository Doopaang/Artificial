using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskDrawer : MonoBehaviour
{
    [SerializeField]
    private Transform drawer;
    [SerializeField]
    private Transform openPos;
    [SerializeField]
    private MoveSceneCamera moveCamera;

    private bool isOpen = false;

    public void Interact()
    {
        if(isOpen)
        {
            CameraSystem.Instance.MoveCamera(moveCamera);
        }
        else
        {
            isOpen = true;

            drawer.position = openPos.position;
        }
    }
}
