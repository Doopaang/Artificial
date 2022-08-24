using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private CabinetDoor cabinetDoor;

    [SerializeField]
    private EItemType deleteItem;

    private MoveSceneCamera moveSceneCamera;

    [HideInInspector]
    public bool opened = false;

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
        Open();
        cabinetDoor.Unlock();
        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }

    public void Open()
    {
        opened = true;
        gameObject.SetActive(false);
    }
}
