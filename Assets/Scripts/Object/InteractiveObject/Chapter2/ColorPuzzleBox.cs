using UnityEngine;

public class ColorPuzzleBox : MonoBehaviour
{
    [SerializeField]
    private GameObject cover;

    [SerializeField]
    private GameObject item;

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
        item.GetComponent<Collider>().enabled = true;
        cover.SetActive(false);
    }
}
