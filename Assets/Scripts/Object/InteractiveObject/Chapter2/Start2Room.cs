using UnityEngine;

public class Start2Room : MonoBehaviour, IEnterCameraEvent
{
    private bool first = true;

    public void OnMoved()
    {
        if (first)
        {
            first = false;

            DialogueSystem.Instance.StartDialogue("2ndRoom");
        }
    }
}
