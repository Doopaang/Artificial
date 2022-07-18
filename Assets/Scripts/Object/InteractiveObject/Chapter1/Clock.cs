using UnityEngine;

public class Clock : MonoBehaviour
{
    public void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EMPTY_WATCH);
        gameObject.SetActive(false);
    }
}
