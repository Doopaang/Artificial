using UnityEngine;

public class CrescentMoon : MonoBehaviour
{
    [SerializeField]
    private WerewolfPicture wereWolfPicture;

    public void Interact()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_CRESCENT_MOON);

        wereWolfPicture.SetGainCrescentMoon();
        wereWolfPicture.ChangeToNight();
    }
}
