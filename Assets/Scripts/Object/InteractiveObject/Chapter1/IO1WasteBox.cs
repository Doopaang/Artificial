using UnityEngine;

public class IO1WasteBox : InteractiveObject
{
    private void Update()
    {
        Debug.Log(Interactable);
    }
    protected override void Interact()
    {
        GameManager.Instance.inventory.DeleteItem(EItemType.CHAPTER1_EATEN_APPLE);
        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_PAPER);
    }
}
