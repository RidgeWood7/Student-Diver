using UnityEngine;

public class Timer : MonoBehaviour
{
    private Phone phone;
    private Controls _controls;

    private void Start()
    {
        phone = FindFirstObjectByType<Phone>();
        _controls = FindAnyObjectByType<Controls>();

        phone.SetTimer();

        if (_controls != null) _controls.doTimerBias = true;
    }
    private void Update()
    {
        if (phone != null && !phone.timerOn)
        {
            if (_controls != null) _controls.doTimerBias = false;
            Destroy(gameObject);
        }
    }
}
