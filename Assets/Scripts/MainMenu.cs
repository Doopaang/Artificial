using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;

    [SerializeField]
    private Image fadeOutImage;

    private void Start()
    {
        SoundSystem.Instance.PlayBGM("MainMenu");
    }

    public void StartGame()
    {
        SoundSystem.Instance.PlaySFX("Button", Camera.main.transform.position);

        foreach (GameObject button in buttons)
            button.SetActive(false);

        DialogueSystem.Instance.StartDialogue("Game_Start", StartFadeOut);
    }

    public IEnumerator FadeOut()
    {
        Color color = fadeOutImage.color;

        for (int i = 0; i <= 100; i++)
        {
            color.a += 0.01f;

            fadeOutImage.color = color;

            yield return new WaitForFixedUpdate();
        }

        SceneManager.LoadScene(1);
    }

    public void StartFadeOut()
    {
        StartCoroutine("FadeOut");
    }

    public void ExitGame()
    {
        SoundSystem.Instance.PlaySFX("Button", Camera.main.transform.position);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void CreditsButton()
    {
        SoundSystem.Instance.PlaySFX("Button", Camera.main.transform.position);

        SceneManager.LoadScene("Credits");
    }
}
