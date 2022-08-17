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
        if (nextStageCamera)
            nextStageCamera.gameObject.SetActive(true);

        if (solveSceneCamera)
            CameraSystem.Instance.MoveCamera(solveSceneCamera);

        if (doorCollider)
            doorCollider.SetActive(false);

        gameObject.transform.Rotate(doorOpenRotaion);
        gameObject.transform.Translate(doorOpenTranslation);

        SoundSystem.Instance.PlaySFX("OpenDoor", transform.position);

        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }
}
