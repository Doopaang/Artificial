using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private CabinetDoor cabinetDoor;

    [SerializeField]
    private EItemType deleteItem;

    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void Solve()
    {
        cabinetDoor.Unlock();
        gameObject.SetActive(false);
        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }
}
