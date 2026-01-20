using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent Event;
    public void Interact()
    {
        Event.Invoke();
    }
}
