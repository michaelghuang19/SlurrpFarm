using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : DragAndDrop
{
    private GameObject shape;
    private float x;
    private float y;
    private Vector2 spawn;
    private GameObject[] shapes;

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Shapes");

        // GameObject randomShape = Instantiate(shapes[0]) as GameObject;
    }

    public void CheckDrop(GameObject draggedObject)
    {
        shape = draggedObject;
        x = shape.transform.position.x;
        y = shape.transform.position.y;
        spawn = shape.transform.position;

        DiamondCheck();
        SquareCheck();
    }
    
    void DiamondCheck()
    {
        if (x >= 10 && x <= 14)
        {
            if (y >= -5 && y <= -1)
            {
                if (shape.name == "Diamond" || shape.name == "Diamond(Clone)")
                {
                    shape.transform.position = new Vector2(12, -3);
                    GameObject.Find("DragAndDrop").GetComponent<SystemProps>().AddScore(shape);
                } else
                {
                    shape.transform.position = spawn;
                }

            }
        }
    }

    void SquareCheck()
    {
        if (x >= 10 && x <= 14)
        {
            if (y >= 1 && y <= 5)
            {
                if (shape.name == "Square" || shape.name == "Square(Clone)")
                {
                    shape.transform.position = new Vector2(12, 3);
                    GameObject.Find("DragAndDrop").GetComponent<SystemProps>().AddScore(shape);
                } else
                {
                    shape.transform.position = spawn;
                }
            }
        }
        
    }
}
