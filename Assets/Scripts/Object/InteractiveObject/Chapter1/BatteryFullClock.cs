using UnityEngine;

public class BatteryFullClock : MonoBehaviour
{
    [SerializeField]
    private Texture dayTexture;

    [SerializeField]
    private Texture nightTexture;

    public void ClickDaytimeButton()
    {
        Debug.Log("Day");

        GetComponent<MeshRenderer>().materials[2].mainTexture = dayTexture;
        GameManager.Instance.ChangeToDaytime();
    }

    public void ClickNightButton()
    {
        Debug.Log("Night");

        GetComponent<MeshRenderer>().materials[2].mainTexture = nightTexture;
        GameManager.Instance.ChangeToNight();
    }
}
