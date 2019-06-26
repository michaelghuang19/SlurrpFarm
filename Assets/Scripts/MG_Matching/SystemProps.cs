using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemProps : MonoBehaviour
{
    public int score = 0;
    public int shapesLeft = 10;
    private GameObject correctShape;
    private GameObject[] shapes;
    // TODO: Maybe a timer?

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Shapes");
    }

    void AddScoreHelper()
    {
        Destroy(correctShape);
        score++;
        shapesLeft--;
        Respawn();
    }

    void Respawn()
    {
        if (shapesLeft != 0)
        {
            // TODO: use Physics.OverlapSphere eventually
            int index = Random.Range(0, shapes.Length);
            GameObject randomShape = Instantiate(shapes[index]) as GameObject;
        }
        return;
        // TODO: quit when necessary
    }

    public void AddScore(GameObject shape)
    {
        correctShape = shape;
        Invoke("AddScoreHelper", 2);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 20), "Score: " + score.ToString());
        GUI.Box(new Rect(160, 10, 200, 20), "Shapes Left: " + shapesLeft.ToString());
    }

}
