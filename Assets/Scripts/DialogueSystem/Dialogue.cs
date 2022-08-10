using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DialogueScript
{
    [TextArea]
    public string text;
    public Sprite sprite;
}

[System.Serializable]
public struct DialogueScriptSet
{
    public string key;
    public List<DialogueScript> scripts;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public List<DialogueScriptSet> scriptSets;

    public DialogueScriptSet FindScriptSetByKey(string key)
    {
        foreach (DialogueScriptSet scriptSet in scriptSets)
        {
            if (scriptSet.key == key)
            {
                return scriptSet;
            }
        }
        throw new System.ArgumentException("Null Key Error.", key);
    }
}
