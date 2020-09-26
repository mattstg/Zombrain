using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerInvoke;
    public EventThatTakesArguments eventThatTakesArgs;
    
    private void OnTriggerEnter(Collider coli)
    {
        onTriggerInvoke.Invoke();
        eventThatTakesArgs.Invoke(coli, coli.name);
    }



    [System.Serializable]
    public class EventThatTakesArguments : UnityEvent<Collider,string>{}

}
