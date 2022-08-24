using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadInGameScene()
    {
        var async = SceneManager.LoadSceneAsync(1);

        yield return new WaitUntil(() => { return async.isDone; });

        FindObjectOfType<SaveData>().Load();
        Destroy(gameObject);
    }
}
