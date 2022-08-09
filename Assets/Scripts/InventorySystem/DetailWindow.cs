using UnityEngine;

public class DetailWindow : MonoBehaviour
{
    [SerializeField]
    private float rotationValue;

    [SerializeField]
    private RectTransform itemDetailPos;

    private GameObject itemDetailObject;

    [SerializeField]
    private BookDetail BookUI;

    public GameObject ItemDetailObject
    {
        get
        {
            return itemDetailObject;
        }
    }

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
    }

    public void SetDetailObject(GameObject prefab)
    {
        itemDetailObject = Instantiate(prefab, itemDetailPos.position, Quaternion.identity, transform);
        Item tempItem = itemDetailObject.GetComponent<Item>();
        itemDetailObject.transform.rotation = tempItem.itemRotation;
        itemDetailObject.transform.localScale = tempItem.scaleDetail;
        itemDetailObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        if (itemDetailObject.GetComponent<Collider>())
            itemDetailObject.GetComponent<Collider>().enabled = false;

        ChangeLayersRecursively(itemDetailObject.transform);

        if (tempItem.itemType >= EItemType.CHAPTER2_BOOK1 &&
            tempItem.itemType <= EItemType.CHAPTER2_BOOK5)
        {
            BookUI.Reset(tempItem.GetComponent<Book>().text);
            BookUI.gameObject.SetActive(true);
        }
        else
        {
            BookUI.gameObject.SetActive(false);
        }
    }

    public void ChangeLayersRecursively(Transform trans)
    {
        trans.gameObject.layer = LayerMask.NameToLayer("UI");

        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child);
        }
    }
}
