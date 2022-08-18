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
    private float blackOutDuration;
    [SerializeField]
    private float endingDuration;

    [Space(20.0f)]
    [SerializeField]
    private Vector3 doorOpenRotaion;
    [SerializeField]
    private Vector3 doorOpenTranslation;

    [Space(20.0f)]
    [SerializeField]
    private FadeInStart fade;
    [SerializeField]
    private MoveSceneCamera solveSceneCamera;
    [SerializeField]
    private BoxCollider puzzleColl;
    [SerializeField]
    private List<Canvas> UIList;
    [SerializeField]
    private Image endingImage;
    [SerializeField]
    private ZoomIn zoomIn;

    private BoxCollider doorColl;

    private bool isSolved = false;

    private void Awake()
    {
        doorColl = GetComponent<BoxCollider>();
    }

    public void SolvedFinalDoor()
    {
        foreach (var temp in UIList)
        {
            temp.gameObject.SetActive(false);
        }
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(false, fadeSpeed, Solve));
    }

    private void Solve()
    {
        isSolved = true;
        CameraSystem.Instance.MoveCamera(solveSceneCamera);
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(true, fadeSpeed, ClearDialogue));
    }

    private void ClearDialogue()
    {
        DialogueSystem.Instance.StartDialogue("Clear_Final_Passworld", ClearDialogueAfter);
    }

    private void ClearDialogueAfter()
    {
        puzzleColl.enabled = false;
        doorColl.enabled = true;
    }

    public void Interact()
    {
        if (!isSolved && zoomIn)
        {
            zoomIn.Interact();
            return;
        }

        SoundSystem.Instance.StopBGM();

        gameObject.transform.Rotate(doorOpenRotaion);
        gameObject.transform.Translate(doorOpenTranslation);
        SoundSystem.Instance.PlaySFX("OpenDoor", transform.position);

        DialogueSystem.Instance.StartDialogue("Ending", () => { StartCoroutine(EndingDialogueAfter()); });

    }

    private IEnumerator EndingDialogueAfter()
    {
        GameManager.Instance.SetInputBlock(true);

        fade.Pop(false);
        SoundSystem.Instance.PlaySFX("EndDump", Camera.main.transform.position);

        yield return new WaitForSeconds(blackOutDuration);

        endingImage.gameObject.SetActive(true);
        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(true, fadeSpeed));

        yield return new WaitForSeconds(endingDuration);

        fade.StartCoroutine("Fade", new FadeInStart.FadeInfo(false, fadeSpeed, MoveScene));
    }

    private void MoveScene()
    {
        fade.Pop(false);
        Cursor.visible = true;
        SceneManager.LoadSceneAsync("Credits");
    }
}
