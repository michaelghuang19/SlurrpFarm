using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemProps : MonoBehaviour
{
    public int score = 0;
    public int shapesLeft = 10;
    private GameObject correctShape;
    private GameObject[] shapes;
    private bool gameover = false;
    private bool timeOn = true;
    private float time = 0;

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Shapes");
    }

    void Update()
    {
        if (timeOn)
        {
            time += Time.deltaTime;
        }
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
            randomShape.transform.position = new Vector2(-12, 0);
        }
        else
        {
            timeOn = false;
            gameover = true;
        }
        // TODO: quit when necessary
    }

    public void AddScore(GameObject shape)
    {
        correctShape = shape;
        Invoke("AddScoreHelper", 1);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 10, 100, 20), "Score: " + score.ToString());
        int timeinseconds = (int) time;
        GUI.Box(new Rect(110, 10, 100, 20), "Time: " + timeinseconds.ToString());
        GUI.Box(new Rect(220, 10, 150, 20), "Shapes Left: " + shapesLeft.ToString());
        if (gameover)
        {
            // fix this, return to screen
            GUI.Label(new Rect(500, 200, 100, 50), "All Shapes Complete in " + timeinseconds + " seconds" );
            Invoke("LoadMenu", 5);
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

}
