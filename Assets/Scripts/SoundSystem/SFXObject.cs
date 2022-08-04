using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXObject : MonoBehaviour
{
    private AudioSource source;

    private Coroutine coroutine;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        PlaySound(clip, Camera.main.transform.position);
    }

    public void Play(AudioClip clip, Vector3 position)
    {
        PlaySound(clip, position);
    }

    private void PlaySound(AudioClip clip, Vector3 position)
    {
        gameObject.SetActive(true);

        transform.position = position;

        source.clip = clip;
        source.Play();

        coroutine = StartCoroutine(OnEnded());
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }

    private IEnumerator OnEnded()
    {
        yield return new WaitUntil(() => { return !source.isPlaying; });

        gameObject.SetActive(false);
    }
}
