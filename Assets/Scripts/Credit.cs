using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    private VideoPlayer player;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    private bool pop = false;

    [SerializeField]
    private double popUpTime;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();

        text.text = System.Environment.MachineName + ".";
    }

    private void Start()
    {
        SoundSystem.Instance.PlayBGM("Credits");
    }

    void Update()
    {
        if (player.isPaused)
        {
            SceneManager.LoadScene(0);
        }
        else if (!pop &&
            player.time >= popUpTime)
        {
            pop = true;
            text.GetComponent<Animator>().SetTrigger("PopUp");
        }
    }
}
