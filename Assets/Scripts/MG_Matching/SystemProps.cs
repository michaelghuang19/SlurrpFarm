using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemProps : MonoBehaviour
{
    public int score = 0;
    public int shapesLeft = 10;
    private GameObject correctShape;
    private GameObject[] shapes;
    // timer, eventually

    // Start is called before the first frame update
    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Shapes");

        // random test
        // GameObject randomShape = Instantiate(shapes[0]) as GameObject;
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
            GameObject randomShape1 = Instantiate(shapes[0]) as GameObject;
            GameObject randomShape2 = Instantiate(shapes[1]) as GameObject;
        }
        // somehow quit when necessary
    }

    public void AddScore(GameObject shape)
    {
        correctShape = shape;
        Invoke("AddScoreHelper", 2);
    }

    // think about some options
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 20), "Score: " + score.ToString());
        GUI.Box(new Rect(160, 10, 200, 20), "Shapes Left: " + shapesLeft.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
