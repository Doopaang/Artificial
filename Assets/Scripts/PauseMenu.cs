using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    public void SaveExit()
    {
        GameManager.Instance.saveData.Save();

        SceneManager.LoadScene(0);
    }
}
