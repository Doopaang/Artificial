public class IO1Apple : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_APPLE);
        Destroy(gameObject);
    }
}
