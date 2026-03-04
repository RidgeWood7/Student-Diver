using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    #region Singleton Declaration
    public static Controls Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    #endregion

    #region Variables

    //camera rotation
    [Range(0f, 10f)] public float _adjustPush;
    public bool _focused;

    //hands
    private bool _rightHolding;
    private bool _leftHolding;

    //camera
    private Camera _camera;

    //added variables
    [Header("Variables")]
    private bool _leftAdded;
    [SerializeField] private float _leftBias = -1;

    private bool _rightAdded;
    [SerializeField] private float _rightBias = 1;

    private bool _openAdded;
    [SerializeField] private float _openBias = 2;

    //interacting
    [Header("Interacting")]
    [SerializeField] private float _interactRange = 20;
    [SerializeField] LayerMask interactLayer;
    [SerializeField] private AnimationCurve _carPosOverLerp;

    //biases
    [Header("Dream Bias")]
    public bool doDreamBias;
    [SerializeField] private bool _dreamAdded;
    [SerializeField] private float _dreamBiasDefault = -.5f;
    [SerializeField] private float _dreamBiasAmt = -.5f;

    [Header("Radio Bias")]
    public bool doRadioBias;
    [SerializeField] private bool _radioAdded;
    [SerializeField] private float _radioBiasDefault = -.5f;
    [SerializeField] private float _radioBiasAmt = -.5f;

    [Header("Call Bias")]
    public bool doCallBias;
    [SerializeField] private bool _callAdded;
    [SerializeField] private float _callBiasDefault = -.5f;
    [SerializeField] private float _callBiasAmt = -.5f;

    [Header("Timer Bias")]
    public bool doTimerBias;
    [SerializeField] private bool _timerAdded;
    [SerializeField] private float _timerBiasDefault = -.5f;
    [SerializeField] private float _timerBiasAmt = -.5f;


    //Car Drift
    [Header("Car Drift")]
    [SerializeField] private float _lerpTarget = 0;
    [SerializeField] private float _lerpFirstPos = 0;
    [SerializeField] private float _lerpBias = 0;
    [SerializeField] private float _lerpSpeed = .2f;
    public bool crashed;
    [SerializeField] private Transform _carObj;
    [SerializeField] private float _driftWidth = 3;

    //Focusing
    [Header("Focusing")]

    //wheel
    [Header("Wheel")]
    [SerializeField] private Transform _wheel;
    [SerializeField] private Transform _targetLeft;
    [SerializeField] private Transform _targetRight;
    [SerializeField] private Transform _default;
    [SerializeField] private Transform _mouseReturn;

    #endregion

    private void Start()
    {
        #region Camera Setting
        _camera = Camera.main;
        if (_camera == null)
            Debug.Log("No Camera Selected");

        _adjustPush = 0;
        #endregion
    }

    private void Update()
    {

        #region Biases

        #region daydreaming

        if (doDreamBias)
        {
            if (!_dreamAdded)
            {
                if (_lerpBias != 0)
                    _dreamBiasAmt = _dreamBiasDefault * (Mathf.Abs(_lerpBias) / _lerpBias);
                else
                    _dreamBiasAmt = _dreamBiasDefault;

                _lerpBias += _dreamBiasAmt;
                _lerpFirstPos = _lerpTarget;
                _dreamAdded = true;
            }
        }
        else if (_dreamAdded)
        {
            _lerpBias -= _dreamBiasAmt;
            _lerpFirstPos = _lerpTarget;
            _dreamAdded = false;
        }

        #endregion

        #region radio

        if (doRadioBias)
        {
            if (!_radioAdded)
            {
                if (_lerpBias != 0)
                    _radioBiasAmt = _radioBiasDefault * (Mathf.Abs(_lerpBias) / _lerpBias);
                else
                    _radioBiasAmt = _radioBiasDefault;

                _lerpBias += _radioBiasAmt;
                _lerpFirstPos = _lerpTarget;
                _radioAdded = true;
            }
        }
        else if (_radioAdded)
        {
            _lerpBias -= _radioBiasAmt;
            _lerpFirstPos = _lerpTarget;
            _radioAdded = false;
        }

        #endregion

        #region call

        if (doCallBias)
        {
            if (!_callAdded)
            {
                if (_lerpBias != 0)
                    _callBiasAmt = _callBiasDefault * (Mathf.Abs(_lerpBias) / _lerpBias);
                else
                    _callBiasAmt = _callBiasDefault;

                _lerpBias += _callBiasAmt;
                _lerpFirstPos = _lerpTarget;
                _callAdded = true;
            }
        }
        else if (_callAdded)
        {
            _lerpBias -= _callBiasAmt;
            _lerpFirstPos = _lerpTarget;
            _callAdded = false;
        }

        #endregion

        #region Timer

        if (doTimerBias)
        {
            if (!_timerAdded)
            {
                if (_lerpBias != 0)
                    _timerBiasAmt = _timerBiasDefault * (Mathf.Abs(_lerpBias) / _lerpBias);
                else
                    _timerBiasAmt = _timerBiasDefault;

                _lerpBias += _timerBiasAmt;
                _lerpFirstPos = _lerpTarget;
                _timerAdded = true;
            }
        }
        else if (_timerAdded)
        {
            _lerpBias -= _timerBiasAmt;
            _lerpFirstPos = _lerpTarget;
            _timerAdded = false;
        }

        #endregion

        #endregion

        #region Holding Bias

        #region Holding True False
        // Sets Left Holding
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            if (_leftHolding == false)
                _leftHolding = true;
        }
        else if (_leftHolding == true)
            _leftHolding = false;

        // Sets Right Holding
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            if (_rightHolding == false)
                _rightHolding = true;
        }
        else if (_rightHolding == true)
            _rightHolding = false;
        #endregion

        // OPEN BIAS
        if (_rightHolding == false && _leftHolding == false)
        {
            if (!_openAdded)
            {
                _lerpBias += _openBias;
                _lerpFirstPos = _lerpTarget;
                _openAdded = true;
            }
        }
        else if (_openAdded == true)
        {
            _lerpBias -= _openBias;
            _lerpFirstPos = _lerpTarget;
            _openAdded = false;
        }

        // LEFT BIAS
        if (_leftHolding && _rightHolding != true)
        {
            if (_leftAdded == true)
            {
                _lerpBias -= _leftBias;
                _lerpFirstPos = _lerpTarget;
                _leftAdded = false;
                _openBias = Mathf.Abs(_openBias) * 1;
            }
        }
        else if (_leftAdded == false)
        {
            _lerpBias += _leftBias;
            _lerpFirstPos = _lerpTarget;
            _leftAdded = true;
        }

        // RIGHT BIAS
        if (_rightHolding && _leftHolding != true)
        {
            if (_rightAdded == true)
            {
                _lerpBias -= _rightBias;
                _lerpFirstPos = _lerpTarget;
                _rightAdded = false;
                _openBias = Mathf.Abs(_openBias) * -1;
            }
        }
        else if (_rightAdded == false)
        {
            _lerpBias += _rightBias;
            _lerpFirstPos = _lerpTarget;
            _rightAdded = true;
        }

        // Mouse Position Set
        if (_mouseReturn != null)
        {
            if (_rightHolding == true)
            {
                Vector2 screenPoint = _camera.WorldToScreenPoint(_mouseReturn.position);
                Mouse.current.WarpCursorPosition(screenPoint);
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }
        }
        #endregion

        #region Interact
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            //showing in scene view for debugging
            Debug.DrawRay(ray.origin, ray.direction * _interactRange, Color.magenta);

            if (Physics.Raycast(ray, out RaycastHit hit, _interactRange, interactLayer))
            {
                if (hit.collider.TryGetComponent(out InteractableObject interactable))
                    interactable.Interact();
            }
        }
        #endregion

        #region Car Drift Effect

        if (_lerpBias > 0 && !crashed) // Move to the right
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpFirstPos) * _lerpBias;

        else if (_lerpBias < 0 && !crashed) // Move to the left
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpFirstPos) * _lerpBias;

        else if ((_lerpTarget > 0.01 || _lerpTarget < -0.01) && !crashed && _lerpTarget != 0) // Reset to zero [IMPLIES "if (_lerpBias == 0)"]
        {
            _lerpTarget += -Mathf.Sign(_lerpTarget) * Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpFirstPos);
        }
        else if (!crashed && _lerpTarget != 0)
        {
            _lerpTarget = 0;
            _lerpFirstPos = 0;
        }


        // clamps the target and sets the car pos based on the target
        if (!crashed && _carObj != null)
        {
            _lerpTarget = Mathf.Clamp(_lerpTarget, -1, 1);
            _carObj.localPosition = new Vector3(_lerpTarget, _carObj.position.y, _carObj.position.z) * _driftWidth;
        }


        // "Crashes the car"
        if (_lerpTarget == 1 || _lerpTarget == -1)
            crashed = true;

        #endregion

        #region Wheel Tilt
        if (_wheel != null && _targetLeft != null && _targetRight != null && _default != null)
        {
            if (_lerpTarget <= 0)
            {
                //left
                _wheel.position = Vector3.Lerp(_default.position, _targetLeft.position, Mathf.Abs(_lerpTarget));
                _wheel.rotation = Quaternion.Lerp(_default.rotation, _targetLeft.rotation, Mathf.Abs(_lerpTarget));
            }
            else if (_lerpTarget >= 0)
            {
                //right
                _wheel.position = Vector3.Lerp(_default.position, _targetRight.position, _lerpTarget);
                _wheel.rotation = Quaternion.Lerp(_default.rotation, _targetRight.rotation, _lerpTarget);
            }
        }
        #endregion

        #region Pushing Adjusting

        if (!_focused && _adjustPush == 10f)
            _focused = true;

        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && !_focused)
            _adjustPush++;

        //add bias adding here
        #endregion
    }
    public void TargetLook(Transform target, float time)
    {
        if (target != null)
        {
            if (target.gameObject.transform.position.z - 4 > gameObject.transform.position.z)
            {
                StartCoroutine(LookOverTime(target, time));
            }
        }
    }
    IEnumerator LookOverTime(Transform target, float time)
    {
        Quaternion originalRotation = _camera.transform.rotation;

        float camX = _camera.GetComponent<Transform>().position.x;
        float camZ = _camera.GetComponent<Transform>().position.z;
        float tarZ = target.gameObject.transform.position.z;
        float tarX = Mathf.Lerp(target.gameObject.transform.position.x, _camera.GetComponent<Transform>().position.x, _adjustPush / 10f);

        float camTargetRotRad = Mathf.Atan2(tarZ - camZ, camX - tarX);
        float degrees = (camTargetRotRad * Mathf.Rad2Deg);
        //calculates this to degrees AND adjusts it to the offset (90)

        Debug.Log(camTargetRotRad);

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            _camera.transform.rotation = Quaternion.Lerp(originalRotation, Quaternion.Euler(0, degrees - 90, 0), t/time);

            yield return new WaitForEndOfFrame();
        }
        _camera.transform.rotation = Quaternion.Euler(0, degrees - 90, 0);
    }
}
