using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private void Start()
    {
        Controls controls = FindFirstObjectByType<Controls>();
        controls.TargetLook(gameObject.transform, 1f);
    }

    private void Update()
    {
        transform.position += new Vector3 (0f,0f,-0.1f * speed);
    }
}
