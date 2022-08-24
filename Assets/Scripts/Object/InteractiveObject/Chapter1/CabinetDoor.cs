using UnityEngine;

public class CabinetDoor : MonoBehaviour
{
    [SerializeField]
    private Collider[] objectColliders;

    [SerializeField]
    private GameObject leftDoor;

    [SerializeField]
    private GameObject rightDoor;

    [SerializeField]
    private MoveSceneCamera CabinetCamera;

    public bool locked = true;

    [HideInInspector]
    public bool opened = false;

    public void Interact()
    {
        if (locked)
        {
            SoundSystem.Instance.PlaySFX("Locked", transform.position);
            return;
        }

        Open();

        SoundSystem.Instance.PlaySFX("Cabinet", transform.position);
    }

    public void Open()
    {
        int rotateDirection = opened ? 1 : -1;

        leftDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * -90.0f, 0.0f));
        rightDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * 90.0f, 0.0f));

        opened = !opened;

        foreach (Collider collider in objectColliders)
        {
            collider.enabled = opened;
        }
    }

    public void Unlock()
    {
        locked = false;

        if (CabinetCamera)
            CameraSystem.Instance.MoveCamera(CabinetCamera);
    }
}
