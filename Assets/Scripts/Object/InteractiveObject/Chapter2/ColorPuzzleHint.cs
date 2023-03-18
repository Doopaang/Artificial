using UnityEngine;

public class ColorPuzzleHint : MonoBehaviour
{
    private MoveSceneCamera moveSceneCamera;

    [HideInInspector]
    public bool usedItem = false;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLASHLIGHT)
        {
            usedItem = true;

            CameraSystem.Instance.MoveCamera(moveSceneCamera);
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_FLASHLIGHT);
        }
        else if (usedItem)
        {
            CameraSystem.Instance.MoveCamera(moveSceneCamera);
        }
    }
}
