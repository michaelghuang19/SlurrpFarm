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

        int index = Random.Range(0, shapes.Length);
        GameObject randomShape = Instantiate(shapes[index]) as GameObject;
        randomShape.transform.position = new Vector2(-12, 0);
    }

    public void CheckDrop(GameObject draggedObject)
    {
        shape = draggedObject;
        x = shape.transform.position.x;
        y = shape.transform.position.y;

        SquareCheck();
        CircleCheck();
        TriangleCheck();
    }

    void SquareCheck()
    {
        if (x >= 10 && x <= 14)
        {
            if (y >= 3 && y <= 4.5)
            {
                if (shape.name == "Square" || shape.name == "Square(Clone)")
                {
                    shape.transform.position = new Vector2(12, 3.5F);
                    GameObject.Find("DragAndDrop").GetComponent<SystemProps>().AddScore(shape);
                } else
                {
                    shape.transform.position = new Vector2(-12, 0);
                }
            }
        }
        
    }

    void CircleCheck()
    {
        if (x >= 10 && x <= 14)
        {
            if (y >= -1 && y <= 1)
            {
                if (shape.name == "Circle" || shape.name == "Circle(Clone)")
                {
                    shape.transform.position = new Vector2(12, 0);
                    GameObject.Find("DragAndDrop").GetComponent<SystemProps>().AddScore(shape);
                }
                else
                {
                    shape.transform.position = new Vector2(-12, 0);
                }
            }
        }

    }

    void TriangleCheck()
    {
        if (x >= 10 && x <= 14)
        {
            if (y >= -4.5 && y <= -2.5)
            {
                if (shape.name == "Triangle" || shape.name == "Triangle(Clone)")
                {
                    shape.transform.position = new Vector2(12, -4);
                    GameObject.Find("DragAndDrop").GetComponent<SystemProps>().AddScore(shape);
                }
                else
                {
                    shape.transform.position = new Vector2(-12,0);
                }

            }
        }
    }
}
