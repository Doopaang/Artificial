using UnityEngine;

public class ColorPuzzleBox : MonoBehaviour
{
    [SerializeField]
    private GameObject cover;

    [SerializeField]
    private GameObject item;

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
        item.GetComponent<Collider>().enabled = true;
        cover.SetActive(false);
        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }
}
