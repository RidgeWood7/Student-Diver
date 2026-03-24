using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    private Controls _controls;

    private void Start()
    {
        _controls = FindFirstObjectByType<Controls>();
        _controls.TargetLook(gameObject.transform, 1f);
        _controls._focused = false;
        _controls._adjustPush = 0;

        if (_controls != null && _controls._adjustPush != 10) _controls.doFocusBias = true;
    }

    private void Update()
    {
        if (_controls != null && _controls._adjustPush == 10) _controls.doFocusBias = false;
        transform.position += new Vector3 (0f,0f,-0.1f * speed * Time.deltaTime * 120f);
        _controls.TargetLook(gameObject.transform, .5f);
    }
}
