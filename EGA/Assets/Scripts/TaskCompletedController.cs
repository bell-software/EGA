using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskCompletedController : MonoBehaviour
{
    public enum TaskType { UI,Action,NA }

    public TaskType taskType;

    [SerializeField]
    private List<GameObject> gameObjectsToEnableList;

    [SerializeField]
    private List<GameObject> gameObjectsToDisableList;


    public UnityEvent FunctionToCall;

    public void EventCaller()
    {
        FunctionToCall.Invoke();

        if (taskType == TaskType.UI)
        {
            foreach (var item in gameObjectsToDisableList)
            {
                item.GetComponent<UITweenController>().SetInactive();
            }

            foreach (var item in gameObjectsToEnableList)
            {
                item.GetComponent<UITweenController>().SetActive();
            }
        }

        
    }



    
}
