using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [HideInInspector]
    public UnityEvent <int> OnInteractionStarted;

    [HideInInspector]
    public UnityEvent <int> OnInteractionCompleted;

    private void Awake()
    {
        if (EventManager.Instance != null)
        {
            Destroy(this);

        }

        EventManager.Instance = this;
    }

}
