using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerDoor : MonoBehaviour
{
    [SerializeField]
    private EItemType LockKey;
    [SerializeField]
    private MoveSceneCamera moveCamera;
    [SerializeField]
    private GameObject doorModel;

    private bool isOpen = false;

    public void OpenDoor()
    {
        if (LockKey != EItemType.NONE)
        {
            if (GameManager.Instance.inventory.UsingItem == LockKey)
            {
                LockKey = EItemType.NONE;
            }
        }
        else if(!isOpen)
        {
            isOpen = true;
            doorModel.SetActive(false);
        }
        else
        {
            if (moveCamera != null)
            {
                CameraSystem.Instance.MoveCamera(moveCamera);
            }
        }
    }
}
