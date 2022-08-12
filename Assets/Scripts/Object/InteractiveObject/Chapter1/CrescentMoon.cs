using UnityEngine;

public class CrescentMoon : MonoBehaviour
{
    [SerializeField]
    private WerewolfPicture wereWolfPicture;

    public void Interact()
    {
        switch(wereWolfPicture.state)
        {
            case EWerewolfPictureType.CrescentMoonNight:
                DialogueSystem.Instance.StartDialogue("Search_Crescent", DropCrescentMoon);
                break;

            case EWerewolfPictureType.Night:
                if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FULL_MOON)
                {
                    wereWolfPicture.StartChangeCoroutine();
                }
                break;
        }
    }

    public void DropCrescentMoon()
    {
        wereWolfPicture.SetGainCrescentMoon();
        wereWolfPicture.ChangeToNight(false);

        DialogueSystem.Instance.StartDialogue("Drop_Crescent", GainCrescentMoon);
    }

    public void GainCrescentMoon()
    {
        GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_CRESCENT_MOON);
    }
}
