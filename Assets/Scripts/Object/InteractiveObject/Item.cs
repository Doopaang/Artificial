using UnityEngine;

public enum EItemType
{
    NONE,
    CHAPTER1_APPLE,
    CHAPTER1_EATEN_APPLE,
    CHAPTER1_OPEN_PUZZLE_PAPER,
    CHAPTER1_BATTERY,
    CHAPTER1_BATTERY_WATCH,
    CHAPTER1_EMPTY_WATCH,
    CHAPTER1_KEY,
    CHAPTER1_CRESCENT_MOON,
    CHAPTER1_BRUSH,
    CHAPTER1_COLOR_DIAL_PUZZLE_PAPER,
    CHAPTER2_KEY_RED,
    CHAPTER2_KEY_YELLOW,
    CHAPTER2_KEY_BLUE,
    CHAPTER2_KEY_GREEN
}

public class Item : MonoBehaviour
{
    public EItemType itemType;
    public EItemType combinableItemType;
    public EItemType combineResultItemType;

    public Sprite itemSprite;

    public Quaternion itemRotation;

    public Vector3 itemScale;
}
