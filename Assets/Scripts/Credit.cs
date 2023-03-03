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

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();

        text.text = " Playing";
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

        if(Input.GetMouseButton(0))
        {
            player.playbackSpeed = 4.0f;
            audioSource.pitch = 2.0f;
        }
        else
        {
            player.playbackSpeed = 1.0f;
            audioSource.pitch = 1.0f;
        }
    }
}
