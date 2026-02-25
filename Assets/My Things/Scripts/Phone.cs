using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject _defaultScreen;
    [SerializeField] private GameObject _callScreen;
    [SerializeField] private GameObject _TimerScreen;
    public enum Screen
    {
        Default,
        Call,
        Timer
    }

    private void Start() => ChangeScreen(Screen.Default);

    public void ChangeScreen(Screen screen)
    {
        switch (screen)
        {
            case Screen.Default:
                _defaultScreen.SetActive(true);
                _callScreen.SetActive(false);
                _TimerScreen.SetActive(false);
                break;
            case Screen.Call:
                _defaultScreen.SetActive(false);
                _callScreen.SetActive(true);
                _TimerScreen.SetActive(false);
                break;
            case Screen.Timer:
                _defaultScreen.SetActive(false);
                _callScreen.SetActive(false);
                _TimerScreen.SetActive(true);
                break;
        }
    }

    public void SetDefault()
    {
        ChangeScreen(Screen.Default);
    }
    public void SetCall()
    {
        ChangeScreen(Screen.Call);
    }
    public void SetTimer()
    {
        ChangeScreen(Screen.Timer);
    }
}
