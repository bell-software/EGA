using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    



    //public void OnStart(int arg)
    //{
        
    //}

    //public void OnComplete(int arg)
    //{

    //}



    //private void Start()
    //{
    //    EventManager.Instance.OnInteractionStarted.AddListener(OnStart);
    //    EventManager.Instance.OnInteractionCompleted.AddListener(OnComplete);

    //}

    //private void OnDisable()
    //{
    //    EventManager.Instance.OnInteractionStarted.RemoveListener(OnStart);
    //    EventManager.Instance.OnInteractionCompleted.RemoveListener(OnComplete);


    //}


    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
        
    }

    public void StopSound()
    { 
    
    }

}
