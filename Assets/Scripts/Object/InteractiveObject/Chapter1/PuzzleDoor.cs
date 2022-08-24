using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenRotaion;

    [SerializeField]
    private Vector3 doorOpenTranslation;

    [SerializeField]
    private GameObject doorCollider;

    [SerializeField]
    private MoveSceneCamera nextStageCamera;

    [SerializeField]
    private MoveSceneCamera moveSceneCamera;

    [SerializeField]
    private MoveSceneCamera solveSceneCamera;

    [SerializeField]
    private EItemType deleteItem;

    [HideInInspector]
    public bool isOpened = false;

    private void Awake()
    {
        if (nextStageCamera)
            nextStageCamera.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void Unlock()
    {
        Open();

        if (solveSceneCamera)
            CameraSystem.Instance.MoveCamera(solveSceneCamera);

        SoundSystem.Instance.PlaySFX("OpenDoor", transform.position);

        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }

    public void Open()
    {
        isOpened = true;

        if (nextStageCamera)
            nextStageCamera.gameObject.SetActive(true);

        if (doorCollider)
            doorCollider.GetComponent<Collider>().enabled = false;

        gameObject.transform.Rotate(doorOpenRotaion);
        gameObject.transform.Translate(doorOpenTranslation);
    }
}
