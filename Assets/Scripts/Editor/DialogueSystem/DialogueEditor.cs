using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor
{
    private Dialogue dialogue;
    void Awake()
    {
        dialogue = (Dialogue)target;
    }

    public override void OnInspectorGUI()
    {

    }
}