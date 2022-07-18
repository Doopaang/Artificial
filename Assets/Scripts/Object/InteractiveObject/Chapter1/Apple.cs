using UnityEngine;

public class Apple : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
        gameObject.SetActive(false);
    }
}
