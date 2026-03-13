using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private bool _isPaused = false;
    [Range (0, 6)] private int _handButtonDown;
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private Image i_A;
    [SerializeField] private Image i_W;
    [SerializeField] private Image i_D;

    [SerializeField] private Image i_L;
    [SerializeField] private Image i_U;
    [SerializeField] private Image i_R;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !_isPaused)
        {
            Time.timeScale = 0;
            _isPaused = true;
        }

        if (_isPaused && Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.RightArrow) == true)
        {
            Time.timeScale = 1;
            _isPaused = false;
        }

        if (i_A != null && i_W != null && i_D != null && i_L != null && i_U != null && i_R != null)
        {
            i_A.enabled = Input.GetKey(KeyCode.A) == true ? true : false;
            i_W.enabled = Input.GetKey(KeyCode.W) == true ? true : false;
            i_D.enabled = Input.GetKey(KeyCode.D) == true ? true : false;
            i_L.enabled = Input.GetKey(KeyCode.LeftArrow) == true ? true : false;
            i_U.enabled = Input.GetKey(KeyCode.UpArrow) == true ? true : false;
            i_R.enabled = Input.GetKey(KeyCode.RightArrow) == true ? true : false;
        }
        else
        {
            Debug.LogWarning("One or more Image references are not set in the inspector.");
        }



        if (_isPaused)
            _pauseScreen.SetActive(true);
        else
            _pauseScreen.SetActive(false);
    }
}
