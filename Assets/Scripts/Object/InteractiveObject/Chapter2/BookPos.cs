using System.Collections.Generic;
using UnityEngine;

public class BookPos : MonoBehaviour
{
    [SerializeField]
    private GameObject mesh;

    private EItemType book = EItemType.NONE;

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
            book = usingItem;
            GameManager.Instance.Inventory.DeleteItem(usingItem);

            List<Item> itemDictionary = GameManager.Instance.itemDictionary;
            foreach(Item item in itemDictionary)
            {
                if(item.itemType == usingItem)
                {
                    bookObject = Instantiate(item.gameObject, transform.position, transform.rotation, transform);

                    break;
                }
            }

            mesh.SetActive(false);
        }
    }
}
