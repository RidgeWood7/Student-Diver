using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject _defaultScreen;
    [SerializeField] private GameObject _callScreen;
    [SerializeField] private GameObject _TimerScreen;

    public bool defaultOn;
    public bool callOn;
    public bool timerOn;

    private void Start() => SetDefault();

    public void SetDefault()
    {
        _defaultScreen.SetActive(true);
        _TimerScreen.SetActive(false);
        _callScreen.SetActive(false);

        defaultOn = true;
        timerOn = false;
        callOn = false;
    }

    public void SetTimer()
    {
        _defaultScreen.SetActive(false);
        _TimerScreen.SetActive(true);
        _callScreen.SetActive(false);

        defaultOn = false;
        timerOn = true;
        callOn = false;
    }

    public void SetCall()
    {
        _defaultScreen.SetActive(false);
        _TimerScreen.SetActive(false);
        _callScreen.SetActive(true);

        defaultOn = false;
        timerOn = false;
        callOn = true;
    }
}
