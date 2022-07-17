using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SwapableObject>().SwapObjectByIndex(1);
            DialogueSystem.Instance.StartDialogue("Test1");
        }
    }
}
