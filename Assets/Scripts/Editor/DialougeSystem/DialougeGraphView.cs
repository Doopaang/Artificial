//using UnityEditor.Experimental.UIElements;
using UnityEditor.Experimental.GraphView;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine.UIElements;

public class DialougeGraphView : GraphView
{
    public DialougeGraphView()
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
    }
}
