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

    //hands
    private bool _rightHolding;
    private bool _leftHolding;

    //camera
    private Camera _camera;
    [SerializeField] private Transform _camTarget;

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

    //Car Drift
    [Header("Car Drift")]
    [SerializeField] private float _lerpTarget = 0;
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
        #endregion
    }

    private void Update()
    {

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
            if (_openAdded == false)
            {
                _lerpBias += _openBias;
                _openAdded = true;
            }
        }
        else if (_openAdded == true)
        {
            _lerpBias -= _openBias;
            _openAdded = false;
        }

        // LEFT BIAS
        if (_leftHolding && _rightHolding != true)
        {
            if (_leftAdded == true)
            {
                _lerpBias -= _leftBias;
                _leftAdded = false;
                _openBias = Mathf.Abs(_openBias) * 1;
            }
        }
        else if (_leftAdded == false)
        {
            _lerpBias += _leftBias;
            _leftAdded = true;
        }

        // RIGHT BIAS
        if (_rightHolding && _leftHolding != true)
        {
            if (_rightAdded == true)
            {
                _lerpBias -= _rightBias;
                _rightAdded = false;
                _openBias = Mathf.Abs(_openBias) * -1;
            }
        }
        else if (_rightAdded == false)
        {
            _lerpBias += _rightBias;
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
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget) * _lerpBias;

        else if (_lerpBias < 0 && !crashed) // Move to the left
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget) * _lerpBias;

        else if ((_lerpTarget > 0.001 || _lerpTarget < -0.001) && !crashed) // Reset to zero [IMPLIES "if (_lerpBias == 0)"]
        {
            if (_lerpTarget != 0)
                _lerpTarget += -Mathf.Sign(_lerpTarget) * Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget);
        }

        else if (!crashed)
            _lerpTarget = 0;


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
    }

    #region Unfocusing
    public void UnfocusLeft(float biasAmt, Transform targetFocus)
    {
        //Transform Looking = 
    }
    #endregion
}










/*

-----------------------------------------------
TO-DO
-----------------------------------------------
[]Fix Holding wheel

[]Car Drift
    *Car Drift Function (will require an input of bias towards a direction) <-------this adds the "bias" of moving the car (one direction)
    *

[]Add Focus LEFT

[]Add Focus RIGHT

[]Move Mouse to Hand When Holding Right Hand on Wheel (and disable it)

[]Add QTE for Focusing
 *maybe make it so that the player has to type "I AM FOCUSED" or something of the sort

[]
-----------------------------------------------
*/
