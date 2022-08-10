using UnityEngine;

public class CrescentMoon : MonoBehaviour
{
    [SerializeField]
    private WerewolfPicture wereWolfPicture;

    public void Interact()
    {
        if (wereWolfPicture.state != EWerewolfPictureType.Night)
        {
            GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER1_CRESCENT_MOON);

            wereWolfPicture.SetGainCrescentMoon();
            wereWolfPicture.ChangeToNight(false);
        }
        else
        {
            /// Test None -> YellowBall
            /// if(GameManager.Instance.Inventory.UsingItem == EItemType.NONE)
            /// {

            wereWolfPicture.StartChangeCoroutine();

            /// }
        }
    }
}
