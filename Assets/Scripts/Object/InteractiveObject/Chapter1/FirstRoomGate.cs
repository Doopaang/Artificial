using UnityEngine;

public class FirstRoomGate : MonoBehaviour
{
    public void Interact()
    {
        DialogueSystem.Instance.StartDialogue("Front_Door");
    }
}
