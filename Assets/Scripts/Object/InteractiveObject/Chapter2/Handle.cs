using UnityEngine;

public class Handle : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(GetComponent<Item>().itemType);
        gameObject.SetActive(false);
    }
}
