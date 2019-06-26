using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : DragAndDrop
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to " + gameObject.name);

    }

    void Update()
    {
        CheckDrop();
    }

    public void CheckDrop()
    {
        DiamondCheck();
        SquareCheck();
    }

    void DiamondCheck()
    {
        Debug.Log("Checking if Diamond!");
    }

    void SquareCheck()
    {
        Debug.Log("Checking if Square!");
    }
}
