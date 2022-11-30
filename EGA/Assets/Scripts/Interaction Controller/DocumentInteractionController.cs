using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentInteractionController : InteractionController
{
    [Header("Document Interaction Controller References")]
    public List<GameObject> documentGameObjects;


    public int currentDocumentNo;
   

    public override void OnStart(int args)
    {
        base.OnStart(args);

        foreach (var item in documentGameObjects)
        {
            item.GetComponent<UITweenController>().SetInactive();
        }
        currentDocumentNo = 1;
        documentGameObjects[currentDocumentNo-1].GetComponent<UITweenController>().SetActive();
        

    }

    public override void OnComplete(int arg)
    {
        base.OnComplete(arg);
        foreach (var item in documentGameObjects)
        {
            item.GetComponent<UITweenController>().SetInactive();
        }
    }

    public void OnChangeDocument(bool isRight)
    {
        if (isRight == true)
        {
            if (currentDocumentNo == documentGameObjects.Count)
            {
                currentDocumentNo = 1;

                documentGameObjects[documentGameObjects.Count - 1].GetComponent<UITweenController>().SetInactive();
                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetActive();
            }
            else
            {
                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetInactive();

                currentDocumentNo += 1;

                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetActive();
            }

        }

        else
        {
            if (currentDocumentNo == 1)
            {
                currentDocumentNo = documentGameObjects.Count;

                documentGameObjects[0].GetComponent<UITweenController>().SetInactive();
                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetActive();
            }
            else
            {
                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetInactive();

                currentDocumentNo -= 1;

                documentGameObjects[currentDocumentNo - 1].GetComponent<UITweenController>().SetActive();
            }
        }

       

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnChangeDocument(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnChangeDocument(true);
        }
    }
}
