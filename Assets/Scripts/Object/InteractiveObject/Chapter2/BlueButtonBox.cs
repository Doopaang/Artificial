using UnityEngine;

public class BlueButtonBox : MonoBehaviour
{
    [SerializeField]
    private GameObject cover;

    [SerializeField]
    private GameObject item;

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
        cover.SetActive(false);
        item.GetComponent<Collider>().enabled = true;
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_PAPER_ARROW);
    }
}
