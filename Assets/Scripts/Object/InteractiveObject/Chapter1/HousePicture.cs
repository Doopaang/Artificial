using UnityEngine;

public enum EHousePictureType
{
    Daytime,
    Night,
    Inside,
    DicePuzzle
}

public class HousePicture : MonoBehaviour
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

    public void ChangePicture(EHousePictureType housePictureType)
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            if (i == (int)housePictureType)
                pictures[i].SetActive(true);
            else
                pictures[i].SetActive(false);
        }
    }
}
