using UnityEngine;

public class ArtYellow : MonoBehaviour
{
    [SerializeField]
    private ReactInteraction reactInteraction;

    [SerializeField]
    private ArtRed red;

    private bool firstInteractFlower = true;

    private MoveSceneCamera moveSceneCamera;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        //if(!usedItem &&
        //    GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_KNIFE)
        //{
        //    GameManager.Instance.Inventory.DeleteItem(EItemType.CHAPTER2_KNIFE);
        //    usedItem = true;

        //    red.ChangeArt();

        //    GameManager.Instance.Inventory.GainItem(EItemType.CHAPTER2_KEY_RED);
        //}

        if (moveSceneCamera)
        {
            CameraSystem.Instance.MoveCamera(moveSceneCamera);

            if (GameManager.Instance.Inventory.UsingItem == EItemType.CHAPTER2_FLOWER)
            {
                if (firstInteractFlower)
                {
                    firstInteractFlower = false;
                    YellowFirstUseFlower();
                }
                else
                    YellowRetryUseFlower();

                return;
            }

            if (reactInteraction)
                reactInteraction.React();
        }
    }

    public void YellowFirstNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_First");
    }

    public void YellowRetryNoneItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Many_Times");
    }

    public void YellowUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Knife");
    }

    public void YellowAfterUseItem()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_After_Gain_Item");
    }

    public void YellowFirstUseFlower()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower");
    }

    public void YellowRetryUseFlower()
    {
        DialogueSystem.Instance.StartDialogue("Yellow_Use_Flower_Many_Times");
    }
}
