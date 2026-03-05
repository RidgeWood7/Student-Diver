using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Controls _controls;

    private void Start()
    {
        _controls = FindFirstObjectByType<Controls>();
        _controls.TargetLook(gameObject.transform, 1f);
        _controls._focused = false;
        _controls._adjustPush = 0;

        if (_controls != null) _controls.doFocusBias = true;
    }

    private void Update()
    {
        transform.position += new Vector3 (0f,0f,-0.1f * speed);
        _controls.TargetLook(gameObject.transform, .5f);
    }
}
