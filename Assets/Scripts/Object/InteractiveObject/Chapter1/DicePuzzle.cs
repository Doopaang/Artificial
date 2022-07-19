using UnityEngine;

public class DicePuzzle : MonoBehaviour
{
    [SerializeField]
    private HousePicture housePicture;

    public void Interact()
    {
        if (housePicture)
            housePicture.ChangePicture(EHousePictureType.DicePuzzle);
    }
}
