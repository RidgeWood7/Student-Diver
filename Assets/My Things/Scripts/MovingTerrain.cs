using UnityEngine;

public class MovingTerrain : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    void Update()
    {
        transform.position += new Vector3 (0f,0f,-0.1f * speed);
    }
}
