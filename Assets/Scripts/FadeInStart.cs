using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInStart : MonoBehaviour
{
    [SerializeField]
    private Image fadeInImage;

    private void Update()
    {
        StartCoroutine("FadeIn");

        if (fadeInImage.color.a <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeInImage.color;

        for (int i = 0; i <= 100; i++)
        {
            color.a -= Time.deltaTime * 0.005f;

            fadeInImage.color = color;
        }

        yield return null;
    }
}
