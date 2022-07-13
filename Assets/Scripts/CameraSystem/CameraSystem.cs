using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : Singleton<CameraSystem>
{
    [SerializeField]
    private MoveSceneCamera currentCamera;

    [System.Serializable]
    private class CameraBaseInspector
    {
        public Button[] CameraButtons = new Button[System.Enum.GetValues(typeof(CameraDirection)).Length - 1];
    }
    [SerializeField, Header("Base"), Tooltip("DON'T TOUCH THIS.")]
    private CameraBaseInspector baseInspector = new CameraBaseInspector();

    private void Start()
    {
        MoveCamera(currentCamera);
    }

    private void ChangeScreen(MoveSceneCamera target)
    {
        currentCamera.SetObjectsActive(false);

        currentCamera = target;

        currentCamera.SetObjectsActive(true);

        for (int i = 0; i < System.Enum.GetValues(typeof(CameraDirection)).Length - 1; i++)
        {
            baseInspector.CameraButtons[i].gameObject.SetActive(currentCamera.CheckNullCamera((CameraDirection)i));
        }
    }

    public void MoveCamera(MoveSceneCamera target)
    {
        ChangeScreen(currentCamera.MoveCamera(target));
    }

    public void MoveCameraDirection(string direction)
    {
        ChangeScreen(currentCamera.MoveScreen(direction));
    }
}
