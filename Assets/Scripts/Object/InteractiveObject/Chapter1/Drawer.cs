using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private bool opened = false;

    private bool locked = false;

    [SerializeField]
    private Vector3 movementVectorForClose;

    public void Interact()
    {
        if (locked)
        {
            return;
        }

        int translateDirection = opened ? 1 : -1;

        transform.Translate(translateDirection * movementVectorForClose, Space.Self);

        opened = !opened;
    }
}
