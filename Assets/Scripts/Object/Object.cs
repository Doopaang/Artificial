using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnMouseDown()
    {
        Interact();
    }

    protected abstract void Interact();
}
