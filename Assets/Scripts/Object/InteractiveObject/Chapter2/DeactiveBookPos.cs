using UnityEngine;

public class DeactiveBookPos : MonoBehaviour, IEnterCameraEvent
{
    [SerializeField]
    private BookshelfEmpty bookshelfEmpty;

    public void OnMoved()
    {
        bookshelfEmpty.DeactiveBookPos();
    }
}
