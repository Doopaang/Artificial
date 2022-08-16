using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenRotaion;

    [SerializeField]
    private Vector3 doorOpenTranslation;

    [SerializeField]
    private MoveSceneCamera nextStageCamera;

    [SerializeField]
    private MoveSceneCamera moveSceneCamera;

    [SerializeField]
    private EItemType deleteItem;

    private void Start()
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

        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);

        gameObject.transform.Rotate(doorOpenRotaion);
        gameObject.transform.Translate(doorOpenTranslation);

        SoundSystem.Instance.PlaySFX("OpenDoor", transform.position);

        GameManager.Instance.Inventory.DeleteItem(deleteItem);
    }
}
