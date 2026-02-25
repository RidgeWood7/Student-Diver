using UnityEngine;

public class Call : MonoBehaviour
{
    private Phone phone;

    private void Start()
    {
        phone = FindFirstObjectByType<Phone>();
        phone.ChangeScreen(Phone.Screen.Call);
    }
}
