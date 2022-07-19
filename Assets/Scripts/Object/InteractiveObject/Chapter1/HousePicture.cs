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

    private bool gateLocked = true;

    public bool GateLocked
    {
        get
        {
            return gateLocked;
        }
    }

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void UnlockGate()
    {
        gateLocked = false;
    }

    public void ChangePicture(EHousePictureType housePictureType)
    {
        if ((housePictureType == EHousePictureType.Daytime ||
            housePictureType == EHousePictureType.Night) && 
            (pictures[(int)EHousePictureType.Inside].activeSelf || 
            pictures[(int)EHousePictureType.DicePuzzle].activeSelf))
        {
            return;
        }

        for (int i = 0; i < pictures.Length; i++)
        {
            if (i == (int)housePictureType)
                pictures[i].SetActive(true);
            else
                pictures[i].SetActive(false);
        }
    }
}
