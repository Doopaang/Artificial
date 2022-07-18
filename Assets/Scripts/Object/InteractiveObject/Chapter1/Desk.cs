using UnityEngine;

public class Desk : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        Debug.Log("Desk");

        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }
}
