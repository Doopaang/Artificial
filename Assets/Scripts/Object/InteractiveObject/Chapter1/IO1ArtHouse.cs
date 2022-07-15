
public class IO1ArtHouse : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_KEY);
    }
}
