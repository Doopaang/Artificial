using UnityEngine;

public class SwapableObject : MonoBehaviour
{
    public void SwapObjectByIndex(int index)
    {
        if (transform.parent.childCount <= index)
            throw new System.IndexOutOfRangeException();

        gameObject.SetActive(false);
        transform.parent.GetChild(index).gameObject.SetActive(true);

        CameraSystem.Instance.MoveCamera(transform.parent.GetChild(index).GetComponentInChildren<MoveSceneCamera>());
    }
}
