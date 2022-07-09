using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!GameManager.Instance.EnableClickObject)
            return;

        Interact();
    }

    protected abstract void Interact();
}
