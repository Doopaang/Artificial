public class IO1Apple : InteractiveObject
{
    protected override void Interact()
    {
        DialogueSystem.Instance.StartDialogue("AppleInteract", GainItem);
    }

    private void GainItem()
    {
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_APPLE);
        Destroy(gameObject);
    }
}
