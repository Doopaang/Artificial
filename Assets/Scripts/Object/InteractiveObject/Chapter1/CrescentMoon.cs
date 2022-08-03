using UnityEngine;

public class CrescentMoon : MonoBehaviour
{
    private bool gainCrescentMoon = false;

    public void Interact()
    {
        if (gainCrescentMoon)
            return;

        gainCrescentMoon = true;

        GameManager.Instance.inventory.GainItem(EItemType.CHAPTER1_CRESCENT_MOON);
    }
}
