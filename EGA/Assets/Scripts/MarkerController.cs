using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [HideInInspector]
    public MeshRenderer mesh;

    public void Awake()
    {

        mesh = GetComponent<MeshRenderer>();
    }

    public virtual void Start()
    {
        EventManager.Instance.OnInteractionStarted.AddListener(OnStart);
        EventManager.Instance.OnInteractionCompleted.AddListener(OnComplete);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mesh.enabled = false;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }

    public virtual void OnStart(int interactionNumber)
    {
    }

    public virtual void OnComplete(int arg)
    {

    }


    private void OnDisable()
    {
        EventManager.Instance.OnInteractionStarted.RemoveListener(OnStart);
        EventManager.Instance.OnInteractionCompleted.RemoveListener(OnComplete);
    }
}
