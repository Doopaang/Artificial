using UnityEngine;

public class CabinetLock : MonoBehaviour
{
    [SerializeField]
    private MoveSceneCamera moveCamera;
    [SerializeField]
    private Transform leftDoor;
    [SerializeField]
    private Transform rightDoor;

    public void Interact()
    {
        if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KEY)
        {
            GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KEY);
            CameraSystem.Instance.MoveCamera(moveCamera);
            Destroy(gameObject);


            Destroy(leftDoor.gameObject);
            Destroy(rightDoor.gameObject);
        }
    }
}
