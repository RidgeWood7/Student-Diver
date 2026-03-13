using UnityEditor;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
