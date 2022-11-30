using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenController : MonoBehaviour
{
    public enum TweenType {Move,Scale,Alpha,MoveAndScale,MoveAndAlpha,ScaleAndAlpha,Tooltip,All};

    public enum ControllerSide {Left,Right,Both,None};


    public TweenType tweenType;
    public ControllerSide controllerSide;

    

    [SerializeField]
    private Vector3 startingPosition;
    [SerializeField]
    private Vector3 endingPosition;

    private bool activated=false;

    [SerializeField]
    private float tweenTime;


    [SerializeField]
    private float delayTime;

    private void Awake()
    {
        if (tweenType == TweenType.Alpha || tweenType == TweenType.MoveAndAlpha || tweenType == TweenType.ScaleAndAlpha || tweenType == TweenType.All || tweenType == TweenType.Tooltip)
        {
            if (gameObject.GetComponent<CanvasGroup>() == null)
            {
                var canvasGroup = gameObject.AddComponent<CanvasGroup>();
                canvasGroup.alpha = 0f;


            }
            if (gameObject.name == "Raise Controller Text")
            {
                Debug.Log("Raise");
                ToggleActivateDeactivate();
            }

            if (gameObject.name == "Controllers")
            {

                ToggleActivateDeactivate();
            }


        }
    }

    

    public void ToggleActivateDeactivate()
    {
        if (activated == true)
        {
            Deactivate();
            activated = false;
        }
        else
        {
            activated = true;
            Activate();
        }
    }

    public void Activate()
    {
        if (tweenType == TweenType.Move)
        {
            LeanTween.move(gameObject, endingPosition, tweenTime);

        }
        else if (tweenType == TweenType.Scale)
        {
            LeanTween.scale(gameObject, Vector2.one, tweenTime);
        }
        else if (tweenType == TweenType.Alpha)
        {
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, tweenTime);
        }

        else if (tweenType == TweenType.MoveAndScale)
        {
            LeanTween.move(gameObject, endingPosition, tweenTime);

            LeanTween.scale(gameObject, Vector2.one, tweenTime);

        }
        else if (tweenType == TweenType.MoveAndAlpha)
        {
            Debug.Log("93");

            LeanTween.moveLocal(gameObject, startingPosition, tweenTime);
            Debug.Log("96");
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, tweenTime);
            Debug.Log("99");
        }
        else if (tweenType == TweenType.ScaleAndAlpha)
        {
            LeanTween.scale(gameObject, Vector2.one, tweenTime);

            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, tweenTime);
        }

        else if (tweenType == TweenType.All)
        {
            LeanTween.moveLocal(gameObject, endingPosition, tweenTime);

            LeanTween.scale(gameObject, Vector2.one, tweenTime);

            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, tweenTime);
        }

        else if (tweenType == TweenType.Tooltip)
        {
            
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, 0.5f).setOnComplete(Deactivate);
            
        }
    }

    public void Deactivate()
    {
        if (tweenType == TweenType.Move)
        {
            LeanTween.move(gameObject, startingPosition, tweenTime);

        }
        else if (tweenType == TweenType.Scale)
        {
            LeanTween.scale(gameObject, Vector2.zero, tweenTime);
        }
        else if (tweenType == TweenType.Alpha)
        {
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, tweenTime);
        }

        else if (tweenType == TweenType.MoveAndScale)
        {
            LeanTween.move(gameObject, startingPosition, tweenTime);

            LeanTween.scale(gameObject, Vector2.zero, tweenTime);

        }
        else if (tweenType == TweenType.MoveAndAlpha)
        {
            LeanTween.move(gameObject, startingPosition, tweenTime);
           

            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, tweenTime);
            
        }
        else if (tweenType == TweenType.ScaleAndAlpha)
        {
            LeanTween.scale(gameObject, Vector2.zero, tweenTime);

            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, tweenTime);
        }

        else if (tweenType == TweenType.All)
        {
            LeanTween.move(gameObject, startingPosition, tweenTime);

            LeanTween.scale(gameObject, Vector2.zero, tweenTime);

            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, tweenTime);
        }
        else if (tweenType == TweenType.Tooltip)
        {
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, tweenTime).setOnComplete(SetInactive).setDelay(3f);
        }
    }

    public void SetSSActive()
    {
        
            gameObject.SetActive(true);
        
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1, tweenTime).setOnComplete(SetSSInactive);
       
        
    }


    public void SetSSInactive()
    {
        
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, tweenTime).setOnComplete(SetObjectSSOff).setDelay(2f);


        
    }

    void SetObjectSSOff()
    {
        
        gameObject.SetActive(false);

    }

    public void SetActive()
    {
        VibrateController(controllerSide);
        gameObject.SetActive(true);
        gameObject.GetComponent<CanvasGroup>().alpha = 0;   
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1, tweenTime).setDelay(delayTime);


    }


    public void SetInactive()
    {

        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, tweenTime).setOnComplete(SetObjectOff);


    }

    void SetObjectOff()
    {
        gameObject.SetActive(false);

    }

    void VibrateController(ControllerSide side)
    {
        //GiveHapticFeedBack.Instance.GiveVibration(side);
    }

}
