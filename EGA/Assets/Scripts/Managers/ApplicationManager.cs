using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public bool playerInInteraction;

    public static ApplicationManager Instance;

    public SoundManager soundManager;

    public InteractionController[] interactionControllers;

    private void Awake()
    {
        if (ApplicationManager.Instance == null)
        {
            ApplicationManager.Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void OnInteractionStarted(int interactionNumber)
    {
        
            EventManager.Instance.OnInteractionStarted?.Invoke(interactionNumber);
            
        
        
    }

    public void OnInteractionCompleted(int arg)
    {
        
            EventManager.Instance.OnInteractionCompleted?.Invoke(arg);
            
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnInteractionCompleted(1);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnInteractionCompleted(2);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnInteractionCompleted(3);

        }


    }


    public void PlaySound(AudioClip audioClip)
    {

        soundManager.PlaySound(audioClip);
        Debug.Log("Playing sound " + audioClip.name);
    }

}
