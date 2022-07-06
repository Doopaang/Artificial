using UnityEditor;
using UnityEngine;

public class DialougeGraph : EditorWindow
{
    [MenuItem("Graph/Dialouge Graph")]
    public static void OpenDialougeGraphWindow()
    {
        EditorWindow window = GetWindow<DialougeGraph>();
        window.titleContent = new GUIContent("Dialouge Graph");
    }
}
