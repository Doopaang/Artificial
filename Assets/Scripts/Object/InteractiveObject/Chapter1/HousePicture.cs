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

    private EHousePictureType state = EHousePictureType.Daytime;

    private MoveSceneCamera moveSceneCamera;

    private bool gateLocked = true;

    private Coroutine coroutine = null;

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

    public void ChangeToDay()
    {
        if (pictures[(int)EHousePictureType.Inside].activeSelf ||
            pictures[(int)EHousePictureType.DicePuzzle].activeSelf)
        {
            return;
        }

        ChangePicture(EHousePictureType.Daytime);
    }

    public void ChangeToNight()
    {
        if (pictures[(int)EHousePictureType.Inside].activeSelf ||
            pictures[(int)EHousePictureType.DicePuzzle].activeSelf)
        {
            return;
        }

        ChangePicture(EHousePictureType.Night);
    }

    public void ChangePicture(EHousePictureType housePictureType)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        MeshRenderer before = pictures[(int)state].GetComponent<MeshRenderer>();
        state = housePictureType;
        MeshRenderer after = pictures[(int)housePictureType].GetComponent<MeshRenderer>();

        coroutine = StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(before, after));
    }
}
