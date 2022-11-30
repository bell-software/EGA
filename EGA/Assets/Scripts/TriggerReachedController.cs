using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerReachedController : MonoBehaviour
{
    public enum ColliderToDetectList {Player,LeftHand,RightHand,Legs,Chest,Head,SafetyNetSpot,None }

    public ColliderToDetectList colliderToDetect;

    public UnityEvent FunctionToCall;

    private void OnTriggerEnter(Collider other)
    {
        var otherTag = other.tag;
        Debug.Log("17 " + otherTag +other.name);
        var colliderName = (colliderToDetect).ToString();
        
        switch (otherTag)
        {
            case "None":
                break;
            case "Chest":
                if (colliderToDetect == ColliderToDetectList.Chest)
                {
                    Debug.Log("52");
                    FunctionToCall.Invoke();
                }
                break;
            case "Legs":
                if (colliderToDetect == ColliderToDetectList.Legs)
                {
                    FunctionToCall.Invoke();
                }
                break;

            case "Player":
                if (colliderToDetect == ColliderToDetectList.Player)
                {
                    FunctionToCall.Invoke();
                }
                break;

            case "LeftHand":
                if (colliderToDetect == ColliderToDetectList.LeftHand)
                {
                    FunctionToCall.Invoke();
                }
                break;
           
            case "RightHand":
                if (colliderToDetect == ColliderToDetectList.RightHand)
                {
                    Debug.Log("line 37");
                    FunctionToCall.Invoke();
                }
                break;
            
            
            
            
            
            case "Head":
                if (colliderToDetect == ColliderToDetectList.Head)
                {
                    FunctionToCall.Invoke();
                }
                break;

            case "SafetyNetSpot":
                if (colliderToDetect == ColliderToDetectList.SafetyNetSpot)
                {
                    Debug.Log("line 37");
                    FunctionToCall.Invoke();
                }
                break;

            default:
                break;
        }



    }
}
