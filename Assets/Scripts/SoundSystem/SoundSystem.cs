using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioDictionary : SerializableDictionary<string, AudioClip> { }

public class SoundSystem : Singleton<SoundSystem>
{
    [SerializeField]
    private int InitSFXCount;
    [SerializeField]
    private float BGMVolume;
    [SerializeField]
    private float SFXVolume;

    [Header("Dictionary")]
    [SerializeField]
    private AudioDictionary BGMDic;
    [SerializeField]
    private AudioDictionary SFXDic;

    [Header("Prefab")]
    [SerializeField]
    private GameObject SFXPrefab;

    private AudioSource BGM;
    private List<SFXObject> SFXList;

    private void Awake()
    {
        BGM = Camera.main.GetComponent<AudioSource>();
        SFXList = new List<SFXObject>();

        for (int i = 0; i < InitSFXCount; i++)
        {
            AddSFX();
        }
    }

    private void Start()
    {
        BGM.volume = BGMVolume;
    }

    private SFXObject AddSFX()
    {
        GameObject newSFX = Instantiate(SFXPrefab, transform);
        newSFX.SetActive(false);

        SFXObject sfx = newSFX.GetComponent<SFXObject>();
        sfx.SetVolume(SFXVolume);
        SFXList.Add(sfx);
        return sfx;
    }

    private SFXObject GetDeactivedSource()
    {
        foreach (SFXObject source in SFXList)
        {
            if (source.gameObject.activeSelf)
            {
                return source;
            }
        }
        return null;
    }

    public void PlayBGM(string key)
    {
        BGM.clip = BGMDic[key];
        BGM.Play();
    }

    public void PlaySFX(string key, Vector3 position)
    {
        SFXObject sfx = GetDeactivedSource();

        if (sfx == null)
        {
            sfx = AddSFX();
        }

        sfx.Play(SFXDic[key], position);
    }
}
