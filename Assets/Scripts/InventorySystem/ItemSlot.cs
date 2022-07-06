using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Image slotImage;

    public Image itemImage;

    public Image selectedImage;

    ItemData item;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ChangeItem(ItemData newItem)
    {
        item = newItem;
        itemImage.sprite = item.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse");
    }
}
