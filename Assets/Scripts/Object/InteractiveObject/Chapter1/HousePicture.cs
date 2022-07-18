using UnityEngine;

public class HousePicture : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }
}
