using System.Collections;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public static bool BobbingEnabled;
    public bool bobbingEnabled;

    private bool _bump;
    private bool _bumping;

    [SerializeField] private float _bumpMagnitude = 0.05f;
    [SerializeField] private float _swayMagnitude = 0.004f;
    [SerializeField] private float _magnitude;
    [SerializeField] private float _speed = 2;

    private Vector3 initialLocalPosition;

    private void Start()
    {
        initialLocalPosition = transform.position;
        _bump = true;
    }

    private void Update()
    {
        BobbingEnabled = bobbingEnabled;

        if (bobbingEnabled)
        {
            if (_bump)
            {
                _bumping = true;
                StartCoroutine(Wait());
            }
            float yOffset = Mathf.PerlinNoise(Time.time * _speed, 0f) * 2f - 1f;
            float xOffset = Mathf.PerlinNoise(0f, Time.time * _speed) * 2f - 1f;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! adjust this if stuff to make it so it bumps and goes back down!!!!!!!!!!!!!!!!!!!!!!!!
            if (_magnitude != _bumpMagnitude && _bumping == true)
            {
                _magnitude = _bumpMagnitude * Time.deltaTime;
            }
            else if (_magnitude != _swayMagnitude && _bumping == true)
            {
                _magnitude = _swayMagnitude * Time.deltaTime;
            }

                Vector3 offset = new Vector3(xOffset, yOffset, 0f) * _magnitude;

            transform.position = initialLocalPosition + offset;
        }
    }

    IEnumerator Wait()
    {
        _bump = false;
        float waitTime = Random.Range(3f, 30f);
        yield return new WaitForSeconds(waitTime);
        _bump = true;
    }
}
