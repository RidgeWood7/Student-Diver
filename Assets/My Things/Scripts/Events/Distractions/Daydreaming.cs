using UnityEngine;
using UnityEngine.InputSystem;

public class Daydreaming : MonoBehaviour
{
    private Phone _phone;
    private Controls _controls;

    [SerializeField] private GameObject _display;

    [Header("bools")]
    private bool _pressedF;
    private bool _pressedO;
    private bool _pressedC;
    private bool _pressedU;
    private bool _pressedS;

    [Header("Displays")]
    [SerializeField] private GameObject fDisplay;
    [SerializeField] private GameObject oDisplay;
    [SerializeField] private GameObject cDisplay;
    [SerializeField] private GameObject uDisplay;
    [SerializeField] private GameObject sDisplay;

    private void Start()
    {
        _display.SetActive(true);

        _controls = FindAnyObjectByType<Controls>();

        if (_controls != null) _controls.doDreamBias = true;
    }

    private void Update()
    {
        if (Time.deltaTime == 0) return;

        if (Keyboard.current.fKey.isPressed && _pressedF == false && _pressedO == false && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("F");
            fDisplay.SetActive(true);
            _pressedF = true;
        }
        if (Keyboard.current.oKey.isPressed && _pressedF == true && _pressedO == false && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("O");
            oDisplay.SetActive(true);
            _pressedO = true;
        }
        if (Keyboard.current.cKey.isPressed && _pressedF == true && _pressedO == true && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("C");
            cDisplay.SetActive(true);
            _pressedC = true;
        }
        if (Keyboard.current.uKey.isPressed && _pressedF == true && _pressedO == true && _pressedC == true && _pressedU == false && _pressedS == false)
        {
            Debug.Log("U");
            uDisplay.SetActive(true);
            _pressedU = true;
        }
        if (Keyboard.current.sKey.isPressed && _pressedF == true && _pressedO == true && _pressedC == true && _pressedU == true && _pressedS == false)
        {
            Debug.Log("S");
            sDisplay.SetActive(true);
            _pressedS = true;
        }

        if (_pressedF == true && _pressedO == true && _pressedC == true && _pressedU == true && _pressedS == true)
        {
            Debug.Log("FOCUS");

            _display.SetActive(false);

            if (_controls != null) _controls.doDreamBias = false;

            Destroy(gameObject);
        }
    }
}
