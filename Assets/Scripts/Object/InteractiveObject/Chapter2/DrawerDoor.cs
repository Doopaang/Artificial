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
                GameManager.Instance.inventory.DeleteItem(LockKey);
                LockKey = EItemType.NONE;

                // 임시 문고리 달기
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
