using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void MoveSceneLeft()
    {
        Camera.main.GetComponent<MoveSceneCamera>().MoveScreenLeft();
    }
}
