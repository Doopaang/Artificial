using UnityEngine;
using UnityEngine.Events;

public class OnMouseDownEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnMouseDownFunction;

    private void OnMouseDown()
    {
        OnMouseDownFunction.Invoke();
    }
}
