using UnityEngine;

public class BlueButtonBox : MonoBehaviour
{
    [SerializeField]
    private GameObject cover;

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
    }
}
