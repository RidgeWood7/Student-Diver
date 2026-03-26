using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DemoVisuals : MonoBehaviour
{

    [SerializeField] private Image i_A;
    [SerializeField] private Image i_W;
    [SerializeField] private Image i_D;

    [SerializeField] private Image i_L;
    [SerializeField] private Image i_U;
    [SerializeField] private Image i_R;

    [SerializeField] private Image i_lCTRL;
    [SerializeField] private Image i_rCTRL;

    //FOCUS KEYS
    [SerializeField] private Image i_F;
    [SerializeField] private Image i_O;
    [SerializeField] private Image i_C;
    [SerializeField] private Image i_Ukey;
    [SerializeField] private Image i_S;

    void Update()
    {
        i_A.enabled = Keyboard.current.aKey.isPressed == true ? true : false;
        i_W.enabled = Keyboard.current.wKey.isPressed == true ? true : false;
        i_D.enabled = Keyboard.current.dKey.isPressed == true ? true : false;
        i_L.enabled = Keyboard.current.leftArrowKey.isPressed == true ? true : false;
        i_U.enabled = Keyboard.current.upArrowKey.isPressed == true ? true : false;
        i_R.enabled = Keyboard.current.rightArrowKey.isPressed == true ? true : false;
        i_lCTRL.enabled = Keyboard.current.leftCtrlKey.isPressed == true ? true : false;
        i_rCTRL.enabled = Keyboard.current.rightCtrlKey.isPressed == true ? true : false;
        i_F.enabled = Keyboard.current.fKey.isPressed == true ? true : false;
        i_O.enabled = Keyboard.current.oKey.isPressed == true ? true : false;
        i_C.enabled = Keyboard.current.cKey.isPressed == true ? true : false;
        i_Ukey.enabled = Keyboard.current.uKey.isPressed == true ? true : false;
        i_S.enabled = Keyboard.current.sKey.isPressed == true ? true : false;
    }
}
