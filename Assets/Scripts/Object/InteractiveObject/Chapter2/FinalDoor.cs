using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private FadeInStart fade;
    [SerializeField]
    private MoveSceneCamera solveSceneCamera;

    [SerializeField]
    private float clearTextDuration;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    private BoxCollider coll;

    [SerializeField]
    private List<Canvas> UIList;

    [SerializeField]
    private Vector3 doorOpenRotaion;
    [SerializeField]
    private Vector3 doorOpenTranslation;

    [SerializeField]
    private Image endingImage;

    [SerializeField]
    private float endTextDuration;

    [SerializeField]
    private float endingDuration;

    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
    }

    public void SolvedFinalDoor()
    {
        GameManager.Instance.SetInputBlock(true);
        foreach (var temp in UIList)
        {
            temp.gameObject.SetActive(false);
        }
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(false, fadeSpeed, Solve1));
    }

    private void Solve1()
    {
        CameraSystem.Instance.MoveCamera(solveSceneCamera);
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(true, fadeSpeed, () => { StartCoroutine(PopText()); }));
    }

    private IEnumerator PopText()
    {
        text.text = "Clear Final Password";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(clearTextDuration);
        text.gameObject.SetActive(false);
        GameManager.Instance.SetInputBlock(false);
        coll.enabled = true;
    }

    public void Interact()
    {
        StartCoroutine(PopText2());
    }

    private IEnumerator PopText2()
    {
        GameManager.Instance.SetInputBlock(true);

        SoundSystem.Instance.StopBGM();

        gameObject.transform.Rotate(doorOpenRotaion);
        gameObject.transform.Translate(doorOpenTranslation);
        SoundSystem.Instance.PlaySFX("OpenDoor", transform.position);

        text.text = "Ending";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(endTextDuration);

        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(false, 1.0f));
        SoundSystem.Instance.PlaySFX("EndDump", Camera.main.transform.position);

        yield return new WaitForSeconds(3.0f);

        endingImage.gameObject.SetActive(true);
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(true, fadeSpeed));

        yield return new WaitForSeconds(endingDuration);

        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(false, fadeSpeed, () => { SceneManager.LoadScene("Credits"); }));
    }
}
