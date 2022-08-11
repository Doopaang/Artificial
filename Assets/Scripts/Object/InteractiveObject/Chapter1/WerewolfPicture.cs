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

    [SerializeField]
    private Collider crescentMoon;

    [HideInInspector]
    public EWerewolfPictureType state = EWerewolfPictureType.Day;

    [SerializeField]
    private float animationDelay;

    private MoveSceneCamera moveSceneCamera;

    private bool isGainCrescentMoon = false;

    private bool firstNightInteract = true;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (moveSceneCamera)
        {
            CameraSystem.Instance.MoveCamera(moveSceneCamera);

            if (firstNightInteract && !GameManager.Instance.IsDaytime)
            {
                firstNightInteract = false;
                DialogueSystem.Instance.StartDialogue("First_Night");
            }
        }
    }

    public void SetGainCrescentMoon()
    {
        isGainCrescentMoon = true;
    }

    public void ChangeToDay()
    {
        ChangePicture(EWerewolfPictureType.Day);
    }

    public void ChangeToNight(bool isFade = true)
    {
        if (isGainCrescentMoon)
        {
            ChangePicture(EWerewolfPictureType.Night, isFade);
        }
        else
        {
            ChangePicture(EWerewolfPictureType.CrescentMoonNight, isFade);
        }
    }

    public void ChangePicture(EWerewolfPictureType werePictureType, bool isFade = true)
    {
        MeshRenderer before = pictures[(int)state].GetComponent<MeshRenderer>();
        state = werePictureType;
        MeshRenderer after = pictures[(int)werePictureType].GetComponent<MeshRenderer>();

        StartCoroutine(GameManager.Instance.FadeCoroutine(before, false, isFade));
        StartCoroutine(GameManager.Instance.FadeCoroutine(after, true, isFade));
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
