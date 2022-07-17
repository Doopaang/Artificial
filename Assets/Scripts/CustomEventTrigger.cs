using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomEventTrigger : MonoBehaviour, IPointerClickHandler
{
    private bool interactable = false;

    [SerializeField]
    private UnityEvent interactCallback;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable)
            return;
        interactCallback.Invoke();
    }
}
