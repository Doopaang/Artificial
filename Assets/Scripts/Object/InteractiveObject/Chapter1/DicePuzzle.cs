using UnityEngine;

public class DicePuzzle : MonoBehaviour
{
    [SerializeField]
    private HousePicture housePicture;

    public void Interact()
    {
        if (housePicture)
        {
            gameObject.SetActive(false);
            housePicture.ChangePicture(EHousePictureType.DicePuzzle);
        }
    }
}
