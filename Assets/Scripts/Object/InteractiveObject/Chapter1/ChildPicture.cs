using UnityEngine;

public class ChildPicture : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    private HungryChildPicture hungryChildPicture;

    private FullChildPicture fullChildPicture;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();

        hungryChildPicture = GetComponentInChildren<HungryChildPicture>();
        fullChildPicture = GetComponentInChildren<FullChildPicture>();

        fullChildPicture.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (moveSceneCamera)
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
    }

    public void ChangeToFullChildPicture()
    {
        hungryChildPicture.gameObject.SetActive(false);
        fullChildPicture.gameObject.SetActive(true);
    }
}
