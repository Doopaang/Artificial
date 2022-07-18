using UnityEngine;

public class CabinetDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject leftDoor;

    [SerializeField]
    private GameObject rightDoor;

    private bool opened = false;

    private bool locked = false;

    public void Interact()
    {
        if (locked)
        {
            return;
        }

        int rotateDirection = opened ? 1 : -1;

        leftDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * 90.0f, 0.0f));
        rightDoor.transform.Rotate(new Vector3(0.0f, rotateDirection * 90.0f, 0.0f));

        opened = !opened;
    }

    public void Unlock()
    {
        locked = false;
    }
}
