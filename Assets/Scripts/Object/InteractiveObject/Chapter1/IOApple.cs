using UnityEngine;

public class IOApple : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_APPLE);
    }
}
