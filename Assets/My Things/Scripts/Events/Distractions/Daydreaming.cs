using UnityEngine;

public class Daydreaming : MonoBehaviour
{
    private bool _pressedF;
    private bool _pressedO;
    private bool _pressedC;
    private bool _pressedU;
    private bool _pressedS;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _pressedF  == false && _pressedO == false && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("F");
            _pressedF = true;
        }
        if (Input.GetKeyDown(KeyCode.O) && _pressedF == true && _pressedO == false && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("O");
            _pressedO = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && _pressedF == true && _pressedO == true && _pressedC == false && _pressedU == false && _pressedS == false)
        {
            Debug.Log("C");
            _pressedC = true;
        }
        if (Input.GetKeyDown(KeyCode.U) && _pressedF == true && _pressedO == true && _pressedC == true && _pressedU == false && _pressedS == false)
        {
            Debug.Log("U");
            _pressedU = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && _pressedF == true && _pressedO == true && _pressedC == true && _pressedU == true && _pressedS == false)
        {
            Debug.Log("S");
            _pressedS = true;
        }

        if (_pressedF == true && _pressedO == true && _pressedC == true && _pressedU == true && _pressedS == true)
        {
            Debug.Log("FOCUS");

            Destroy(gameObject);
        }
    }
}
