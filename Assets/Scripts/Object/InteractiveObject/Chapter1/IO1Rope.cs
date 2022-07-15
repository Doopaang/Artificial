
public class IO1Rope : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_CRESCENT_MOON);
    }
}
