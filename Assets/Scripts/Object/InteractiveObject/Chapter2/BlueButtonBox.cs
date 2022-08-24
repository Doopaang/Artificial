using UnityEngine;

public class BlueButtonBox : MonoBehaviour
{
    [SerializeField]
    private GameObject cover;

    [SerializeField]
    private GameObject item;

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
        GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_PAPER_ARROW);
    }

    public void Open()
    {
        solved = true;
        cover.SetActive(false);
        item.GetComponent<Collider>().enabled = true;
    }
}
