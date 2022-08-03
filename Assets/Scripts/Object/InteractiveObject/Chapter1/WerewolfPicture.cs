using UnityEngine;

public enum EWerewolfPictureType
{
    Daytime,
    Night
}

public class WerewolfPicture : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pictures;

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

    public void ChangePicture(EWerewolfPictureType werePictureType)
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            if (i == (int)werePictureType)
                pictures[i].SetActive(true);
            else
                pictures[i].SetActive(false);
        }
    }
}
