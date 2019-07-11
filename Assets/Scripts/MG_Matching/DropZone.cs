using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : DragAndDrop
{
    private GameObject shape;
    private float x;
    private float y;
    private GameObject[] shapes;

    private ParticleSystem correctCheese;
    private ParticleSystem correctTomato;
    private ParticleSystem correctBanana;

    void Start()
    {
        correctCheese = GameObject.Find("correctCheese").GetComponent<ParticleSystem>();
        correctTomato = GameObject.Find("correctTomato").GetComponent<ParticleSystem>();
        correctBanana = GameObject.Find("correctBanana").GetComponent<ParticleSystem>();

        shapes = Resources.LoadAll<GameObject>("Sprites/MinigameElements/Shapes");

        int index = Random.Range(0, shapes.Length);
        GameObject randomShape = Instantiate(shapes[index]) as GameObject;
        randomShape.transform.position = new Vector2(-6, 0);
    }

    public void CheckDrop(GameObject draggedObject)
    {
        shape = draggedObject;
        x = shape.transform.position.x;
        y = shape.transform.position.y;

        CheeseCheck();
        TomatoCheck();
        BananaCheck();
    }

    void CheeseCheck()
    {
        if (x >= 5 && x <= 8)
        {
            if (y >= 2.5 && y <= 4)
            {
                if (shape.name == "Cheese" || shape.name == "Cheese(Clone)")
                {
                    shape.transform.position = new Vector2(6.5F, 3.5F);
                    correctCheese.Play();
                    GetComponent<SystemProps>().AddScore(shape);
                } else
                {
                    shape.transform.position = new Vector2(-6, 0);
                }
            }
        }
    }

    void TomatoCheck()
    {
        if (x >= 4 && x <= 7)
        {
            if (y >= -1.5 && y <= 1.5)
            {
                if (shape.name == "Tomato" || shape.name == "Tomato(Clone)")
                {
                    shape.transform.position = new Vector2(6, 0);
                    correctTomato.Play();
                    GetComponent<SystemProps>().AddScore(shape);
                }
                else
                {
                    shape.transform.position = new Vector2(-6, 0);
                }
            }
        }
    }

    void BananaCheck()
    {
        if (x >= 3 && x <= 6)
        {
            if (y >= -4 && y <= -2)
            {
                if (shape.name == "Banana" || shape.name == "Banana(Clone)")
                {
                    shape.transform.position = new Vector2(5, -3.5F);
                    correctBanana.Play();
                    GetComponent<SystemProps>().AddScore(shape);
                }
                else
                {
                    shape.transform.position = new Vector2(-6,0);
                }
            }
        }
    }
}
