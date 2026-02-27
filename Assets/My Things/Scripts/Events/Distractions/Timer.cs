using UnityEngine;

public class Timer : MonoBehaviour
{
    private Phone _phone;
    private Controls _controls;

    private void Start()
    {
        _phone = FindFirstObjectByType<Phone>();
        _controls = FindAnyObjectByType<Controls>();

        _phone.SetTimer();

        if (_controls != null) _controls.doTimerBias = true;
    }
    private void Update()
    {
        if (_phone != null && !_phone.timerOn)
        {
            if (_controls != null) _controls.doTimerBias = false;
            Destroy(gameObject);
        }
    }
}
