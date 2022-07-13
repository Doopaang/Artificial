public class IO1HungryChild : InteractiveObject
{
    protected override void Interact()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_EATEN_APPLE);
        DialogueSystem.Instance.StartDialogue("Test1");
    }
}
