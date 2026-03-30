using UnityEngine;
using UnityEngine.EventSystems;

public class KillEvents : MonoBehaviour
{
    private void Awake()
    {
        EventSystem existingSystem = FindFirstObjectByType<EventSystem>();

        if (existingSystem != null && existingSystem != this.GetComponent<EventSystem>())
        {
            Destroy(this.gameObject);
        }
    }
}
