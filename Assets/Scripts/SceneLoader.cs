using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private SaveData saveData = new SaveData();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadInGameScene()
    {
        var async = SceneManager.LoadSceneAsync(1);
        while (!async.isDone)
        {
            yield return null;
        }

        saveData.Load();
        Destroy(gameObject);
    }
}
