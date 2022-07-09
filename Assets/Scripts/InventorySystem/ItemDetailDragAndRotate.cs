using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailDragAndRotate : MonoBehaviour
{
    [SerializeField]
    private Camera itemDetailCamera;

    [SerializeField]
    private float rotationValue;

    private GameObject itemDetailObject;

    void Start()
    {
        itemDetailObject = GameManager.Instance.inventory.ItemDetailObject;
    }

    void Update()
    {
        if (GameManager.Instance.inventory.IsActivatedItemDetailWindow)
        {
            if (Input.GetMouseButton(0))
            {
                float rotX = Input.GetAxis("Mouse X") * rotationValue * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * rotationValue * Mathf.Deg2Rad;

                itemDetailObject.transform.Rotate(itemDetailCamera.transform.up, -rotX, Space.World);
                itemDetailObject.transform.Rotate(itemDetailCamera.transform.right, rotY, Space.World);
            }
        }
    }
}
