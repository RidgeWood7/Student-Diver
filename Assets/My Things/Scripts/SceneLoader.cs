using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneFunFacts(string sceneName)
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        FunFacts.LoadScene(sceneName);
    }
    public void LoadScene(string sceneName)
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
