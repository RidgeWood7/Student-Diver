using System.Collections;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public static bool BobbingEnabled;
    public bool bobbingEnabled;

    private bool _bump;
    private bool _bumping;
    private bool _afterBumping;

    [SerializeField] private float _bumpMagnitude = 0.05f;
    [SerializeField] private float _swayMagnitude = 0.004f;
    [SerializeField] private float _magnitude;
    [SerializeField] private float _speed = 2;

    [SerializeField] private float _bumpTime = 2f;
    [SerializeField] private float _afterBumpTime = 2f;

    [SerializeField] private Transform camTarget;
    private Vector3 camLocalPosition;

    private void Start()
    {
        _magnitude = _swayMagnitude;
        StartCoroutine(Wait());
        _afterBumping = false;
    }

    private void Update()
    {
        BobbingEnabled = bobbingEnabled;

        if (bobbingEnabled && camLocalPosition != null)
        {
            camLocalPosition = camTarget.localPosition;

            if (_bump)
            {
                _magnitude = _swayMagnitude;
                _bumping = true;
                StartCoroutine(Wait());
            }

            float yOffset = Mathf.PerlinNoise(Time.time * _speed, 0f) * 2f - 1f;
            float xOffset = Mathf.PerlinNoise(0f, Time.time * _speed) * 2f - 1f;

            if (_bumping == true)
            {
                if (_magnitude < _bumpMagnitude * 0.95f)
                {
                    //_magnitude += _bumpMagnitude * Time.deltaTime * _bumpTime;
                    _magnitude = Mathf.Lerp(_magnitude, _bumpMagnitude, Time.deltaTime * _bumpTime);
                }
                else
                {
                    _magnitude = _bumpMagnitude;
                    _bumping = false;
                    _afterBumping = true;
                }
            }
            if (_afterBumping == true)
            {
                if (_magnitude > _swayMagnitude * 1.05f)
                {
                    //_magnitude -= _swayMagnitude * Time.deltaTime * _afterBumpTime;
                    _magnitude = Mathf.Lerp(_magnitude, _swayMagnitude, Time.deltaTime * _afterBumpTime);
                }
                else
                {
                    _magnitude = _swayMagnitude;
                    _afterBumping = false;
                }
            }

            Vector3 offset = new Vector3(xOffset, yOffset, 0f) * _magnitude;

            transform.localPosition = camLocalPosition + offset;
        }
    }

    IEnumerator Wait()
    {
        _bump = false;
        float waitTime = Random.Range(10f, 60f);
        yield return new WaitForSeconds(waitTime);
        _bump = true;
    }
}
