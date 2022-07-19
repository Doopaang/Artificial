using UnityEngine;

public class Battery : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_BATTERY);
        gameObject.SetActive(false);
    }
}
