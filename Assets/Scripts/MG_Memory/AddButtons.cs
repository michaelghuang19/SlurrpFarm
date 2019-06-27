using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btnField;

    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(btnField);
            button.name = "" + i;
            //Second param of SetParent is worldPositionStays, meaning that if it is true,
            //the item will stay in the same place it currently is, even after being assigned to a parent
            button.transform.SetParent(puzzleField, false);
        }
    }
}
