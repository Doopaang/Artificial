using UnityEngine;

[Icon("CameraIcon")]
public class MoveSceneCamera : MonoBehaviour
{
    [SerializeField]
    public MoveSceneCamera left;
    [SerializeField]
    private MoveSceneCamera right;
    [SerializeField]
    private MoveSceneCamera up;
    [SerializeField]
    private MoveSceneCamera down;
    [SerializeField]
    private MoveSceneCamera back;

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "CameraIcon", true);
    }

    private void OnDrawGizmosSelected()
    {
        Camera camera = Camera.main;
        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        if (camera.orthographic)
        {
            float spread = camera.farClipPlane - camera.nearClipPlane;
            float center = (camera.farClipPlane + camera.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(camera.orthographicSize * 2 * camera.aspect, camera.orthographicSize * 2, spread));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, camera.fieldOfView, camera.farClipPlane, camera.nearClipPlane, camera.aspect);
        }
        Gizmos.matrix = temp;
    }

    public MoveSceneCamera MoveScreen(string direction)
    {
        switch (direction)
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

    private MoveSceneCamera MoveCamera(MoveSceneCamera target)
    {
        Camera.main.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
        return target;
    }

    public bool CheckNullCamera(CameraDirection direction)
    {
        switch (direction)
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