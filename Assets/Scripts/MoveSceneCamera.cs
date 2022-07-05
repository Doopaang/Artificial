using UnityEngine;

public class MoveSceneCamera : MonoBehaviour
{
    [SerializeField]
    private Camera left;
    [SerializeField]
    private Camera right;
    [SerializeField]
    private Camera up;
    [SerializeField]
    private Camera down;
    [SerializeField]
    private Camera back;

    public void MoveScreenLeft()
    {
        MoveCamera(left);
    }

    public void MoveScreenRight()
    {

    }
    public void MoveScreenUp()
    {

    }
    public void MoveScreenDown()
    {

    }

    public void MoveScreenBack()
    {

    }

    private void MoveCamera(Camera target)
    {
        Camera.main.gameObject.SetActive(false);
        target.gameObject.SetActive(true);
    }
}
