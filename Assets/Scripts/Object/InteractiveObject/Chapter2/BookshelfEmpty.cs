using UnityEngine;

public class BookshelfEmpty : MonoBehaviour
{
    [SerializeField]
    private BookPos[] bookPosArray;

    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        ActiveBookPos();

        CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void ActiveBookPos()
    {
        foreach (BookPos bookPos in bookPosArray)
        {
            if (bookPos.book == EItemType.NONE)
            {
                bookPos.Mesh.SetActive(true);
            }
        }
    }

    public void DeactiveBookPos()
    {
        foreach (BookPos bookPos in bookPosArray)
        {
            bookPos.Mesh.SetActive(false);
        }
    }
}
