using UnityEngine;

public class Start2Room : MonoBehaviour, IEnterCameraEvent
{
    [HideInInspector]
    public bool first = true;

    public void OnMoved()
    {
        if (first)
        {
            first = false;

            DialogueSystem.Instance.StartDialogue("2ndRoom");
        }
    }
}
