using UnityEngine;

public class ChildPicture : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    private HungryChildPicture hungryChildPicture;

    private FullChildPicture fullChildPicture;

    [HideInInspector]
    public bool changed = false;

    private void Awake()
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

    public void ChangeToFullChildPicture(bool isLoad = false)
    {
        changed = true;

        MeshRenderer before = hungryChildPicture.GetComponent<MeshRenderer>();
        MeshRenderer after = fullChildPicture.GetComponent<MeshRenderer>();

        StartCoroutine(GameManager.Instance.ChangeFadeCoroutine(before, after, false, () => { fullChildPicture.Interact(); }, isLoad));
    }
}
