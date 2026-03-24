using UnityEngine;

public class MovingTerrain : MonoBehaviour
{
    [SerializeField] private float speed = 4;

    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.position += new Vector3(0f, 0f, -0.1f * speed * Time.deltaTime * 120f);
        }
    }
}
