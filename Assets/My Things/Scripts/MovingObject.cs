using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Controls controls;

    private void Start()
    {
        controls = FindFirstObjectByType<Controls>();
        controls.TargetLook(gameObject.transform, 1f);
        controls._focused = false;
        controls._adjustPush = 0;
    }

    private void Update()
    {
        transform.position += new Vector3 (0f,0f,-0.1f * speed);
        controls.TargetLook(gameObject.transform, .5f);

    }
}
