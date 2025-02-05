using UnityEngine;
using UnityEngine.Events;

public class ReactInteraction : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ReactFirstNoneItem;

    [SerializeField]
    private UnityEvent ReactRetryNoneItem;

    [SerializeField]
    private UnityEvent ReactFirstUsingItem;

    [SerializeField]
    private UnityEvent ReactRetryUsedItem;

    public bool retryInteraction = false;
    public bool usedItem = false;

    public EItemType necessaryItem;

    public void React()
    {
        if (!usedItem &&
            necessaryItem != EItemType.NONE &&
            GameManager.Instance.Inventory.UsingItem == necessaryItem)
        {
            usedItem = true;
            ReactFirstUsingItem.Invoke();
        }
        else if (usedItem)
        {
            ReactRetryUsedItem.Invoke();
        }
        else if (!retryInteraction)
        {
            retryInteraction = true;
            ReactFirstNoneItem.Invoke();
        }
        else
        {
            ReactRetryNoneItem.Invoke();
        }
    }
}
