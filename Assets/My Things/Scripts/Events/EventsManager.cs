using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [SerializeField] private List<GameEvent> _events = new List<GameEvent>();

    private void Start()
    {
        StartCoroutine(EventHandler());
    }
    IEnumerator EventHandler()
    {
        foreach (GameEvent e in _events)
        {
            var newobject = Instantiate(e.eventObject);
            yield return new WaitForSeconds(e.waitTime);
        }
    }
}