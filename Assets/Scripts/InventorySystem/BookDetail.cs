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

    public void Reset(string text)
    {
        textPanel.SetActive(false);
        this.text.text = text;
        this.text.pageToDisplay = 1;
        downBtn.interactable = false;
        upBtn.interactable = true;
    }

    public void PlusPage(int value)
    {
        text.pageToDisplay += value;

        downBtn.interactable = text.pageToDisplay > 1;
        upBtn.interactable = text.pageToDisplay < text.textInfo.pageCount;
    }
}
