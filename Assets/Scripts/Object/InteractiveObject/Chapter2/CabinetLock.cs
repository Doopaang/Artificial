using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetLock : MonoBehaviour
{
    [SerializeField]
    private MoveSceneCamera moveCamera;
    [SerializeField]
    private Transform leftDoor;
    [SerializeField]
    private Transform rightDoor;

    public void Interact()
    {
        if (GameManager.Instance.inventory.UsingItem == EItemType.CHAPTER2_TEMP1)
        {
            CameraSystem.Instance.MoveCamera(moveCamera);
            Destroy(gameObject);


            Destroy(leftDoor.gameObject);
            Destroy(rightDoor.gameObject);
        }
    }
}
