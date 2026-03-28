using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private AudioSource sound;

    public UnityEvent nextLevel;

    public void EndTheGame()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);

        if (sound != null)
            sound.Play();
        else
            Debug.LogWarning("AudioSource reference is not set in the inspector.");

        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(6f);
        Time.timeScale = 1;
        nextLevel.Invoke();
    }
}
