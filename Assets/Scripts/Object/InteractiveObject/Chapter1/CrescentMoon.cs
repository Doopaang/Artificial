using UnityEngine;

public class CrescentMoon : MonoBehaviour
{
    [SerializeField]
    private WerewolfPicture wereWolfPicture;

    public void Interact()
    {
        if (wereWolfPicture.state != EWerewolfPictureType.Night)
        {
            DialogueSystem.Instance.StartDialogue("Search_Crescent", DropCrescentMoon);
        }
        else
        {
            // Test None -> YellowBall
            // if(GameManager.Instance.Inventory.UsingItem == EItemType.NONE)
            // {

            wereWolfPicture.StartChangeCoroutine();
            //DialogueSystem.Instance.StartDialogue("After_Effect");

            // }
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
