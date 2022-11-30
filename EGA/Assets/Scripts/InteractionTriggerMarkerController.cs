using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTriggerMarkerController : MarkerController
{
    public int interactionNumber;

    public Color preInteraction, midInteraction, postInteraction;

    public enum MarkerState
    {
        preInteraction,
        midInteraction,
        postInteraction
    }

    public MarkerState currentMarkerState = MarkerState.preInteraction;

    public override void Start()
    {
        base.Start();

        mesh.material.color = preInteraction;
    }


    public override void OnTriggerEnter(Collider other)
    {
            base.OnTriggerEnter(other);

            if (other.CompareTag("Player") && currentMarkerState == MarkerState.preInteraction && ApplicationManager.Instance.playerInInteraction == false)
            {
                
                EventManager.Instance.OnInteractionStarted?.Invoke(interactionNumber);

            }
            
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }


    public override void OnStart(int _interactionNumber)
    {
        if(_interactionNumber == interactionNumber)
        {
            ApplicationManager.Instance.playerInInteraction = true;
            mesh.material.color = midInteraction;
            currentMarkerState = MarkerState.midInteraction;
        }    
    }

    public override void OnComplete(int arg)
    {
        if (arg == interactionNumber)
        {
            if (currentMarkerState == MarkerState.midInteraction || currentMarkerState == MarkerState.preInteraction)
            {
                ApplicationManager.Instance.playerInInteraction = false;
                mesh.material.color = postInteraction;
                currentMarkerState = MarkerState.postInteraction;
            }
        }
    }
}
