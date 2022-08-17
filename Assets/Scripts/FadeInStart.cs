using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeInStart : MonoBehaviour
{
    [SerializeField]
    private Image fadeInImage;

    public struct FadeInfo
    {
        public bool isIn;
        public float speed;
        public UnityAction afterEvent;

        public FadeInfo(bool isIn, float speed, UnityAction afterEvent = null)
        {
            this.isIn = isIn;
            this.speed = speed;
            this.afterEvent = afterEvent;
        }
    }

    private void Start()
    {
        StartCoroutine("Fade", new FadeInfo(true, 0.01f));
    }

    private IEnumerator Fade(FadeInfo info)
    {
        Color color = fadeInImage.color;

        fadeInImage.gameObject.SetActive(true);
        while (info.isIn && fadeInImage.color.a > 0.0f ||
            !info.isIn && fadeInImage.color.a < 1.0f)
        {
            color.a += info.speed * (info.isIn ? -1.0f : 1.0f);

            fadeInImage.color = color;

            yield return new WaitForFixedUpdate();
        }
        fadeInImage.gameObject.SetActive(false);
        if (info.afterEvent != null)
        {
            info.afterEvent.Invoke();
        }
    }
}
