using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteractionController : InteractionController
{
    private bool isGoodCondition = true;

    [Header("Toggle Interaction Controller References")]
    public List<GameObject> goodConditionGameObjects;

    public List<GameObject> badConditionGameObjects;

    public override void OnStart(int args)
    {
        base.OnStart(args);


    }

    public override void OnComplete(int arg)
    {
        base.OnComplete(arg);
    }

    public void ToggleGoodAndBad()
    {
        if (isGoodCondition == false)
        {
            foreach (var item in goodConditionGameObjects)
            {
                item.SetActive(true);
            }

            foreach (var item in badConditionGameObjects)
            {
                item.SetActive(false);
            }
        }

        else if (isGoodCondition == true)
        {
            foreach (var item in goodConditionGameObjects)
            {
                item.SetActive(false);
            }

            foreach (var item in badConditionGameObjects)
            {
                item.SetActive(true);
            }
        }

        isGoodCondition = !isGoodCondition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleGoodAndBad();
        }
    }

}
