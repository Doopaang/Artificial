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

    [HideInInspector]
    public bool solved = false;

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
        SoundSystem.Instance.PlaySFX("OpenBox", transform.position);
        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }

    public void Open()
    {
        solved = true;
        item.GetComponent<Collider>().enabled = true;
        cover.SetActive(false);
    }
}
