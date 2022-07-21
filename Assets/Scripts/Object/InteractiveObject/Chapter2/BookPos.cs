using System.Collections.Generic;
using UnityEngine;

public class BookPos : MonoBehaviour
{
    private EItemType book = EItemType.NONE;

    private GameObject bookObject = null;

    public void Interact(int num)
    {
        EItemType usingItem = GameManager.Instance.inventory.UsingItem;

        if (book != EItemType.NONE)
        {
            GameManager.Instance.inventory.GainItem(book);
            book = EItemType.NONE;
            Destroy(bookObject);
        }
        else if (usingItem >= EItemType.CHAPTER2_BOOK1 &&
            usingItem <= EItemType.CHAPTER2_BOOK5)
        {
            book = usingItem;
            GameManager.Instance.inventory.DeleteItem(usingItem);

            List<Item> itemDictionary = GameManager.Instance.itemDictionary;
            foreach(Item item in itemDictionary)
            {
                if(item.itemType == usingItem)
                {
                    bookObject = Instantiate(item.gameObject, transform.position, transform.rotation, transform);

                    break;
                }
            }
        }
    }
}
