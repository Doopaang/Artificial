using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DialogueScript
{
    public Sprite sprite;
    public string text;
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
    [SerializeField]
    private List<DialogueScriptSet> scriptSets;

    public DialogueScriptSet FindScriptSetByKey(string key)
    {
        foreach(DialogueScriptSet scriptSet in scriptSets)
        {
            if(scriptSet.key == key)
            {
                return scriptSet;
            }
        }
        throw new System.ArgumentException("다이얼로그에 맞는 Key값이 없습니다. 아래 값과 일치하는 Key값이 있는지 확인하세요.", key);
    }
}
