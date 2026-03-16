using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunFacts : MonoBehaviour
{
    [SerializeField] private List<string> Facts = new List<string>();
    [SerializeField] private TMPro.TMP_Text text;

    public static string NextSceneName;

    private void Start()
    {
        Facts = Facts.OrderBy(_ => UnityEngine.Random.Range(-1f, 1f)).ToList();
        text.text = Facts.First();
    }

    public static void LoadScene(string nextSceneName)
    {
        Time.timeScale = 1f;
        NextSceneName = nextSceneName;
        SceneManager.LoadScene("FunFacts");
    }
    
    public static void LoadSetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(NextSceneName);
    }
}
