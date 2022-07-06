using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Canvas UICanvas;
    [SerializeField]
    private Button[] CameraButtons = new Button[System.Enum.GetValues(typeof(CameraDirection)).Length - 1];

    private void Start()
    {
        ChangeCamera(Camera.main);
    }

    private void ChangeCamera(Camera target)
    {
        UICanvas.worldCamera = target;

        MoveSceneCamera sceneCamera = Camera.main.GetComponent<MoveSceneCamera>();

        for (int i = 0; i < System.Enum.GetValues(typeof(CameraDirection)).Length - 1; i++)
        {
            CameraButtons[i].gameObject.SetActive(sceneCamera.CheckNullCamera((CameraDirection)i));
        }
    }

    public void MoveCamera(Camera target)
    {
        ChangeCamera(target);
    }

    public void MoveCameraDirection(string direction)
    {
        ChangeCamera(Camera.main.GetComponent<MoveSceneCamera>().MoveScreen(direction));
    }
}
