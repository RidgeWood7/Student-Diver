using UnityEngine;

public class Call : MonoBehaviour
{
    private Phone _phone;
    private Controls _controls;

    private void Start()
    {
        _phone = FindFirstObjectByType<Phone>();
        _controls = FindAnyObjectByType<Controls>();

        _phone.SetCall();
        
        if (_controls != null) _controls.doCallBias = true;
    }
    private void Update()
    {
        if (_phone != null && !_phone.callOn)
        {
            if (_controls != null) _controls.doCallBias = false;
            Destroy(gameObject);
        }
    }
}
