using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    private bool _isPaused = true;
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private Image i_A;
    [SerializeField] private Image i_W;
    [SerializeField] private Image i_D;

    [SerializeField] private Image i_L;
    [SerializeField] private Image i_U;
    [SerializeField] private Image i_R;

    private void Awake()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void Update()
    {
        if (_isPaused && Keyboard.current.aKey.isPressed == true && Keyboard.current.wKey.isPressed == true && Keyboard.current.dKey.isPressed == true && Keyboard.current.leftArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed == true && Keyboard.current.rightArrowKey.isPressed == true)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            _pauseScreen.SetActive(false);
            _isPaused = false;
        }

        if (i_A != null && i_W != null && i_D != null && i_L != null && i_U != null && i_R != null)
        {
            i_A.enabled = Keyboard.current.aKey.isPressed == true ? true : false;
            i_W.enabled = Keyboard.current.wKey.isPressed == true ? true : false;
            i_D.enabled = Keyboard.current.dKey.isPressed == true ? true : false;
            i_L.enabled = Keyboard.current.leftArrowKey.isPressed == true ? true : false;
            i_U.enabled = Keyboard.current.upArrowKey.isPressed == true ? true : false;
            i_R.enabled = Keyboard.current.rightArrowKey.isPressed == true ? true : false;
        }
        else
        {
            Debug.LogWarning("One or more Image references are not set in the inspector.");
        }
    }
}
