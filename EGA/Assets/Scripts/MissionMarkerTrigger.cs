using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionMarkerTrigger : MonoBehaviour
{
    public UnityEvent OnMarkerReached;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnMarkerReached.Invoke();
            gameObject.SetActive(false);

        }
    }
}
