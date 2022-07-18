using UnityEngine;

public class Apple : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_APPLE);
        gameObject.SetActive(false);
    }
}
