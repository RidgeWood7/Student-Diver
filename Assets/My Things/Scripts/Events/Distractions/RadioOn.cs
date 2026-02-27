using UnityEngine;

public class RadioOn : MonoBehaviour
{
    private Radio _radio;
    private Controls _controls;

    private void Start()
    {
        _radio = FindFirstObjectByType<Radio>();
        _controls = FindFirstObjectByType<Controls>();

        _radio.TurnOn();

        if (_controls != null) _controls.doRadioBias = true;
        Debug.Log("radio on");
    }

    private void Update()
    {
        if (_radio != null)
        {
            if (!_radio.isOn)
            {
                if (_controls != null) _controls.doRadioBias = false;

                Destroy(gameObject);
            }
        }
    }
}
