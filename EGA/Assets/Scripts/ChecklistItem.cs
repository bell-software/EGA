using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistItem : MonoBehaviour
{
    public int interactionNumber;

    public KeyCode testKey;

    public void CompleteInteraction()
    {
        ApplicationManager.Instance.OnInteractionCompleted(interactionNumber);
        GetComponent<UnityEngine.UI.Toggle>().interactable = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(testKey))
        {
            GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        }
    }
}
