using System.Collections;
using UnityEngine;

public enum EWerewolfPictureType
{
    Day,
    CrescentMoonNight,
    Night,
    FullMoonNight,
    Animating,
    Werewolf
}

public class WerewolfPicture : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pictures;
    [HideInInspector]
    public EWerewolfPictureType state = EWerewolfPictureType.Day;
    [SerializeField]
    private float animationDelay;

    private MoveSceneCamera moveSceneCamera;

    private bool isGainCrescentMoon = false;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void SetGainCrescentMoon()
    {
        isGainCrescentMoon = true;
    }

    public void ChangeToDay()
    {
        ChangePicture(EWerewolfPictureType.Day);
    }

    public void ChangeToNight()
    {
        if (isGainCrescentMoon)
        {
            ChangePicture(EWerewolfPictureType.Night);
        }
        else
        {
            ChangePicture(EWerewolfPictureType.CrescentMoonNight);
        }
    }

    public void ChangePicture(EWerewolfPictureType werePictureType)
    {
        state = werePictureType;

        for (int i = 0; i < pictures.Length; i++)
        {
            if (i == (int)werePictureType)
                pictures[i].SetActive(true);
            else
                pictures[i].SetActive(false);
        }
    }

    public void StartChangeCoroutine()
    {
        StartCoroutine(WerewolfAnimation());
    }

    private IEnumerator WerewolfAnimation()
    {
        GameManager.Instance.SetInputBlock(true);

        ChangePicture(EWerewolfPictureType.FullMoonNight);

        yield return new WaitForSeconds(animationDelay);

        ChangePicture(EWerewolfPictureType.Animating);

        yield return new WaitForSeconds(animationDelay);

        ChangePicture(EWerewolfPictureType.Werewolf);

        GameManager.Instance.SetInputBlock(false);
    }
}
