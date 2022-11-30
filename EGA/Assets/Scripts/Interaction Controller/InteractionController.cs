using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    
    [Header("Interaction Controller References")]

    public Transform lockPositionTransform;

    public GameObject uIInstruction;


    public AudioClip startSound;

    public AudioClip endSound;

    [Header ("Objects to enable on start and disable on complete")]
    public List<GameObject> interactionSpecificObjects;
    
    public virtual void OnStart(int interactionNumber)
    {
        Debug.Log("start" + interactionNumber);

        uIInstruction.GetComponent<UITweenController>().SetActive();

        if (ApplicationManager.Instance.interactionControllers[interactionNumber] == GetComponent<InteractionController>())
        {
            ApplicationManager.Instance.PlaySound(startSound);

            foreach (var obj in interactionSpecificObjects)
            {
                obj.SetActive(true);
            }

        }
        else
            print(ApplicationManager.Instance.interactionControllers[interactionNumber]);
        
    }

    public virtual void OnComplete(int interactionNumber)
    {
        if (ApplicationManager.Instance.interactionControllers[interactionNumber] == GetComponent<InteractionController>())
        {
            uIInstruction.GetComponent<UITweenController>().SetInactive();

            ApplicationManager.Instance.PlaySound(endSound);

            foreach (var obj in interactionSpecificObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public virtual void Start()
    {

        EventManager.Instance.OnInteractionStarted.AddListener(OnStart);
        EventManager.Instance.OnInteractionCompleted.AddListener(OnComplete);

    }

    private void OnDisable()
    {

        EventManager.Instance.OnInteractionStarted.RemoveListener(OnStart);
        EventManager.Instance.OnInteractionCompleted.RemoveListener(OnComplete);

    }
}
