using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookDetail : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private GameObject textPanel;
    [SerializeField]
    private Button downBtn;
    [SerializeField]
    private Button upBtn;

    private void Start()
    {
        gameObject.SetActive(false);
        textPanel.SetActive(false);
    }

    public void Reset(string text)
    {
        textPanel.SetActive(false);
        this.text.SetText(text);
        this.text.pageToDisplay = 1;
        this.text.ForceMeshUpdate(true);
        CheckButton();
    }

    public void PlusPage(int value)
    {
        text.pageToDisplay += value;
        CheckButton();
        SoundSystem.Instance.PlaySFX("Inventory", Camera.main.transform.position);
    }

    private void CheckButton()
    {
        downBtn.interactable = text.pageToDisplay > 1;
        upBtn.interactable = text.pageToDisplay < text.textInfo.pageCount;
    }
}
