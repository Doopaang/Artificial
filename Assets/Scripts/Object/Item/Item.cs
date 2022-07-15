using UnityEngine;

public class Item : MonoBehaviour
{
    public EItemType itemType;
    public EItemType combinableItemType;
    public EItemType combineResultItemType;

    public Sprite itemSprite;

    public Quaternion itemRotation;

    public Vector3 itemScale;
}
