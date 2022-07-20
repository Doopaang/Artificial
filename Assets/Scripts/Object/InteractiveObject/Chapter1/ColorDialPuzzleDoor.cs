using UnityEngine;

public class ColorDialPuzzleDoor : MonoBehaviour
{
    [SerializeField]
    private MoveSceneCamera nextStageCamera;

    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();

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
    }
}
