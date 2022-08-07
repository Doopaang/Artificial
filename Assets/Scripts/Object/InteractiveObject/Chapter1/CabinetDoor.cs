using UnityEngine;

public class CabinetDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject leftDoor;

    [SerializeField]
    private GameObject rightDoor;

    [SerializeField]
    private MoveSceneCamera CabinetCamera;

    [SerializeField]
    private Lock dialLock;

    [SerializeField]
    private bool locked = true;

    private bool opened = false;

    public void Interact()
    {
        if (locked)
        {
            return;
        }

        int rotateDirection = opened ? 1 : -1;

        leftDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * -90.0f, 0.0f));
        rightDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * 90.0f, 0.0f));

        opened = !opened;
    }

    public void Unlock()
    {
        locked = false;

        dialLock.gameObject.SetActive(false);

        if (CabinetCamera)
            CameraSystem.Instance.MoveCamera(CabinetCamera);
    }
}
