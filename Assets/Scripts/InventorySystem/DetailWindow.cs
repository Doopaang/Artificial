using UnityEngine;
using UnityEngine.Events;

public class DetailWindow : MonoBehaviour
{
    [SerializeField]
    private float rotationValue;

    [SerializeField]
    private RectTransform itemDetailPos;

    private GameObject itemDetailObject;

    [SerializeField]
    private BookDetail BookUI;

    private UnityAction afterEvent = null;

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

        if (afterEvent != null)
        {
            afterEvent.Invoke();
            afterEvent = null;
        }
    }

    public void SetDetailObject(GameObject prefab, UnityAction afterEvent = null)
    {
        itemDetailObject = Instantiate(prefab, itemDetailPos.position, Quaternion.identity, transform);
        Item tempItem = itemDetailObject.GetComponent<Item>();
        itemDetailObject.transform.rotation = tempItem.itemRotation;
        itemDetailObject.transform.localScale = tempItem.scaleDetail;

        if (itemDetailObject.GetComponent<MeshRenderer>())
            itemDetailObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        if (itemDetailObject.GetComponent<Collider>())
            itemDetailObject.GetComponent<Collider>().enabled = false;

        ChangeLayersRecursively(itemDetailObject.transform);

        if (tempItem.itemType >= EItemType.CHAPTER2_BOOK1 &&
            tempItem.itemType <= EItemType.CHAPTER2_BOOK5)
        {
            BookUI.gameObject.SetActive(true);
            BookUI.Reset(tempItem.GetComponent<Book>().text);
        }
        else
        {
            BookUI.gameObject.SetActive(false);
        }

        if (afterEvent != null)
        {
            this.afterEvent = afterEvent;
        }
    }

    public void ChangeLayersRecursively(Transform trans)
    {
        trans.gameObject.layer = LayerMask.NameToLayer("UI");

        if (trans.GetComponent<MeshRenderer>())
            trans.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child);
        }
    }
}
