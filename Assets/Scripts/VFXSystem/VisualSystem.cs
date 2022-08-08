using System.Collections;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class VisualSystem : Singleton<VisualSystem>
{
    [SerializeField]
    private ShakeData shakeData;

    [SerializeField]
    private Canvas blackOutCanvas;

    private bool blackOut;

    public void StartShakeCamera()
    {
        StopShakeCamera();

        CameraShakerHandler.Shake(shakeData);
    }

    public void StopShakeCamera()
    {
        if (CameraShakerHandler.Shaking)
        {
            CameraShakerHandler.Stop();
        }
    }

    public void StartBlackOut()
    {
        StopBlackOut();

        blackOut = true;
        blackOutCanvas.gameObject.SetActive(true);
    }

    public void StopBlackOut()
    {
        if (blackOut)
        {
            blackOut = false;
            blackOutCanvas.gameObject.SetActive(false);
        }
    }
}
