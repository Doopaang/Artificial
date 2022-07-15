using UnityEngine;

public class DetailWindow : MonoBehaviour
{
    [SerializeField]
    private float rotationValue;

    [SerializeField]
    private RectTransform itemDetailPos;

    private GameObject itemDetailObject;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * rotationValue * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotationValue * Mathf.Deg2Rad;

            itemDetailObject.transform.Rotate(itemDetailPos.up, -rotX, Space.World);
            itemDetailObject.transform.Rotate(itemDetailPos.right, rotY, Space.World);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);

        Destroy(itemDetailObject);
        itemDetailObject = null;

        GameManager.Instance.DecreaseActivatedUINum();
    }

    public void SetDetailObject(GameObject prefab)
    {
        itemDetailObject = Instantiate(prefab, itemDetailPos.position, Quaternion.identity, transform);
        itemDetailObject.transform.rotation = itemDetailObject.GetComponent<Item>().itemRotation;
        itemDetailObject.transform.localScale = itemDetailObject.GetComponent<Item>().itemScale;
        itemDetailObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        itemDetailObject.layer = LayerMask.NameToLayer("UI");
    }
}
