using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour
{
    [SerializeField]
    private MoveSceneCamera showcaseCamera;

    [SerializeField]
    private LockNum dialLock1;

    [SerializeField]
    private LockNum dialLock2;

    [SerializeField]
    private CameraMoveObject dialLockZoomIn1;

    [SerializeField]
    private CameraMoveObject dialLockZoomIn2;

    public void UnlockDial1()
    {
        if (!showcaseCamera || !dialLock1 || !dialLockZoomIn1)
            return;

        Destroy(dialLockZoomIn1);
        CameraSystem.Instance.MoveCamera(showcaseCamera);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EMPTY_WATCH);
    }

    public void UnlockDial2()
    {
        if (!showcaseCamera || !dialLock2 || !dialLockZoomIn2)
            return;

        Destroy(dialLockZoomIn2);
        CameraSystem.Instance.MoveCamera(showcaseCamera);
    }
}
