using UnityEngine;

public class PuzzleNumPad : MonoBehaviour
{
    [SerializeField]
    private GameObject PuzzlePadUI;

    private MoveSceneCamera moveSceneCamera;

    private bool firstInteract = true;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (PuzzlePadUI && moveSceneCamera)
        {
            PuzzlePadUI.SetActive(true);
            CameraSystem.Instance.MoveCamera(moveSceneCamera);

            if (firstInteract)
                firstInteract = false;
        }
    }
}
