using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField]
    private MoveSceneCamera currentCamera;

    [SerializeField]
    private Button[] CameraButtons = new Button[System.Enum.GetValues(typeof(CameraDirection)).Length - 1];

    private void Start()
    {
        MoveCamera(currentCamera);
    }

    private void ChangeScreen(MoveSceneCamera target)
    {
        currentCamera = target;

        for (int i = 0; i < System.Enum.GetValues(typeof(CameraDirection)).Length - 1; i++)
        {
            CameraButtons[i].gameObject.SetActive(currentCamera.CheckNullCamera((CameraDirection)i));
        }
    }

    public void MoveCamera(MoveSceneCamera target)
    {
        ChangeScreen(target);
    }

    public void MoveCameraDirection(string direction)
    {
        ChangeScreen(currentCamera.MoveScreen(direction));
    }
}
