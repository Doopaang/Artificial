using UnityEngine;

public class ChildPicture : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }
    public void Interact()
    {
        Debug.Log("In");

        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }
}
