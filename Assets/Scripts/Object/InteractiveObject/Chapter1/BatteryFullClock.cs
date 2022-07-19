using UnityEngine;

public class BatteryFullClock : MonoBehaviour
{
    public void ClickDaytimeButton()
    {
        Debug.Log("Day");
        GameManager.Instance.ChangeToDaytime();
    }

    public void ClickNightButton()
    {
        Debug.Log("Night");
        GameManager.Instance.ChangeToNight();
    }
}
