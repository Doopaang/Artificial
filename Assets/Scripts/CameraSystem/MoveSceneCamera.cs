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

    public Camera MoveScreen(string direction)
    {
        switch(direction)
        {
            case "left":
                return MoveCamera(left);

            case "right":
                return MoveCamera(right);

            case "up":
                return MoveCamera(up);

            case "down":
                return MoveCamera(down);

            case "back":
                return MoveCamera(back);

            default:
                throw new System.ArgumentException();
        }
    }

    private Camera MoveCamera(Camera target)
    {
        Camera.main.gameObject.SetActive(false);
        target.gameObject.SetActive(true);
        return target;
    }

    public bool CheckNullCamera(CameraDirection direction)
    {
        switch(direction)
        {
            case CameraDirection.Up:
                return up != null;

            case CameraDirection.Down:
                return down != null;

            case CameraDirection.Left:
                return left != null;

            case CameraDirection.Right:
                return right != null;

            case CameraDirection.Back:
                return back != null;

            default:
                throw new System.ArgumentException();
        }
    }
}
