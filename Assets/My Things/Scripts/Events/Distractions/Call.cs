using UnityEngine;

public class Call : MonoBehaviour
{
    private Phone phone;
    private Controls _controls;

    private void Start()
    {
        phone = FindFirstObjectByType<Phone>();
        _controls = FindAnyObjectByType<Controls>();

        phone.SetCall();
        
        if (_controls != null) _controls.doCallBias = true;
    }
    private void Update()
    {
        if (phone != null && !phone.callOn)
        {
            if (_controls != null) _controls.doCallBias = false;
            Destroy(gameObject);
        }
    }
}
