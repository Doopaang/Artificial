using UnityEngine;

public class DialPannel : MonoBehaviour
{
    [SerializeField]
    private GameObject PuzzlePadUI;

    private MoveSceneCamera moveSceneCamera;

    private bool firstInteract = true;

    private void Start()
    {
        moveSceneCamera = GetComponentInChildren<MoveSceneCamera>();
    }

    public void Interact()
    {
        if (PuzzlePadUI && moveSceneCamera)
        {
            PuzzlePadUI.SetActive(true);
            CameraSystem.Instance.MoveCamera(moveSceneCamera);

            if (firstInteract)
            {
                firstInteract = false;

                DialogueSystem.Instance.StartDialogue("Door_To_2ndRoom");
            }
        }
    }
}
