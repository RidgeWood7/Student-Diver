using UnityEngine;

public class Radio : MonoBehaviour
{
    public bool isOn;

    private void Update()
    {
        if (isOn)
        {

        }
        else
        {

        }
    }

    public void TurnOff()
    {
        isOn = false;
    }

    public void TurnOn()
    {
        isOn = true;
    }
}
