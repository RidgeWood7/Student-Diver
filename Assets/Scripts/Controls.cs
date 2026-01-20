using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering.HighDefinition;
using UnityEngine;
using UnityEngine.UIElements;

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
    //Holding
    public bool LeftHolding;
    public bool RightHolding;

    //interacting
    [SerializeField] private float _interactRange = 20;
    [SerializeField] LayerMask interactLayer;
    private Camera _camera;

    [SerializeField] private AnimationCurve _carPosOverLerp;

    //Car Drift
    [SerializeField] private float _lerpTarget = 0;
    [SerializeField] private float _lerpBias = 0;
    [SerializeField] private float _lerpSpeed = .2f;
    [SerializeField] private Transform _carObj;
    public bool crashed;

    //Focusing

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

        #region Left Hand Hold
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {
            LeftHolding = true;
        }
        #endregion

        #region Right Hand Holding
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightHolding = true;
        }
        #endregion

        #region Interact
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //showing in scene view for debugging
        Debug.DrawRay(ray.origin, ray.direction * _interactRange, Color.magenta);

        if (Physics.Raycast(ray, out RaycastHit hit, _interactRange, interactLayer))
        {
            Debug.Log("Looking at: " + hit.transform.name);

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out InteractableObject interactable))
                    interactable.Interact();
            }
        }

        #endregion

        #region Car Drift Effect

        if (_lerpTarget == 1 || _lerpTarget == -1)
            crashed = true;


        if (_lerpBias > 0 && !crashed) // Move to the right
        {
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget) * _lerpBias;
        }
        else if (_lerpBias < 0 && !crashed) // Move to the left
        {
            _lerpTarget += Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget) * _lerpBias;
        }
        else if (_lerpTarget > 0.001 || _lerpTarget < -0.001 && !crashed)// Reset to zero
        {
            if (_lerpTarget != 0)
            {
                _lerpTarget += -Mathf.Sign(_lerpTarget) * Time.deltaTime * _lerpSpeed * _carPosOverLerp.Evaluate(_lerpTarget);
            }
        }
        else if (!crashed)
        {
            _lerpTarget = 0;
        }

        if (!crashed)
        {
            _lerpTarget = Mathf.Clamp(_lerpTarget, -1, 1);
            _carObj.position = new Vector3(_lerpTarget, _carObj.position.y) * 3;
        }
        #endregion
    }

    public void CarDrift()
    {

    }
}










/*

-----------------------------------------------
TO-DO
-----------------------------------------------
[]Car Drift
    *Car Drift Function (will require an input of bias towards a direction) <-------this adds the "force" of moving the car (one direction)
    *

[]Add Focus LEFT

[]Add Focus RIGHT

[]Move Mouse to Hand When Holding Right Hand on Wheel (and disable it)

[]Add QTE for Focusing
 *maybe make it so that the player has to type "I AM FOCUSED" or something of the sort

[]
-----------------------------------------------
*/
