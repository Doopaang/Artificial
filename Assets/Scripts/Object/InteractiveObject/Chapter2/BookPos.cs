using System.Collections.Generic;
using UnityEngine;

public class BookPos : MonoBehaviour
{
    [SerializeField]
    private GameObject mesh;

    [SerializeField]
    public EItemType book = EItemType.NONE;

    private GameObject bookObject = null;

    public GameObject Mesh
    {
        get
        {
            return mesh;
        }
    }

    public void Interact()
    {
        EItemType usingItem = GameManager.Instance.Inventory.UsingItem;

        if (book != EItemType.NONE)
        {
            GameManager.Instance.Inventory.GainItem(book);
            book = EItemType.NONE;
            Destroy(bookObject);
            mesh.SetActive(true);
        }
        else if (usingItem >= EItemType.CHAPTER2_BOOK1 &&
            usingItem <= EItemType.CHAPTER2_BOOK5)
        {
            SetBook(usingItem);

            GameManager.Instance.Inventory.DeleteItem(usingItem);
        }

        GameManager.Instance.saveData.SaveBookPos(this, book);
    }

    public void SetBook(EItemType itemType)
    {
        if (itemType == EItemType.NONE)
        {
            return;
        }

        book = itemType;

        Item item = GameManager.Instance.itemDictionary.Find((A) => { return A.itemType == itemType; });
        bookObject = Instantiate(item.gameObject, transform.position, transform.rotation, transform);

        mesh.SetActive(false);
    }
}
