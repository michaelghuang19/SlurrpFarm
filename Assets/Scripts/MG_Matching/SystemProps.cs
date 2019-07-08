using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemProps : MonoBehaviour
{
    public int score = 0;
    public int shapesLeft = 10;
    private GameObject correctShape;
    private GameObject[] shapes;
    private bool gameover = false;
    private bool gameWon = false;
    private bool timeOn = true;
    private float time = 0;
    private int GameID = 1;

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Sprites/MinigameElements/Shapes");
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
            int index = UnityEngine.Random.Range(0, shapes.Length);
            GameObject randomShape = Instantiate(shapes[index]) as GameObject;
            randomShape.transform.position = new Vector2(-7, 0);
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
        GUI.Box(new Rect(0, 10, 200, 50), "Score: " + score.ToString());
        int timeinseconds = (int) time;
        GUI.Box(new Rect(210, 10, 200, 50), "Time: " + timeinseconds.ToString());
        GUI.Box(new Rect(420, 10, 250, 50), "Shapes Left: " + shapesLeft.ToString());
        if (gameover)
        {
            // fix this, return to screen
            GUI.Label(new Rect(500, 200, 100, 50), "All Shapes Complete in " + timeinseconds + " seconds" );
            SetExp();
            Invoke("LoadMenu", 5);
        }
    }

    void SetExp() {
        CheckDefaultPrefs();
        
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        int CurEXP = PlayerPrefs.GetInt("CurExp");
        int PrevGameCount = PlayerPrefs.GetInt("PrevGameCount");
        int PrevGame = PlayerPrefs.GetInt("PrevGame");

        bool levelChanged = false;
        bool gameChanged = false;

        int exp = 0;

        if (gameWon) {
            exp+=100;
        } else {
            exp+=34;
        }

        if (PrevGame != GameID) {
            PrevGameCount = 0;
            gameChanged = true;
        } else {
            PrevGameCount +=1;
        }
        exp = (int) (exp * (Math.Pow(0.8, PrevGameCount - 1)));
        CurEXP += exp;
        if (PlayerLevel == 1) {
            if (CurEXP >= 100) {
                PlayerLevel += 1;
                CurEXP -= 100;
                levelChanged = true;
            }
        } else if (PlayerLevel == 2) {
            if (CurEXP >= 200) {
                PlayerLevel += 1;
                CurEXP -= 200;
                levelChanged = true;
            }
        } else {
            if (CurEXP >= 300) {
                PlayerLevel += 1;
                CurEXP -= 300;
                levelChanged = true;
            }
        }

        PlayerPrefs.SetInt("CurEXP", CurEXP);
        PlayerPrefs.SetInt("PrevGameCount", PrevGameCount);
        if (levelChanged) {
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);
        }
        if (gameChanged) {
            PlayerPrefs.SetInt("PrevGame", GameID);
        }
    }

    void CheckDefaultPrefs() {
        if (!PlayerPrefs.HasKey("PlayerLevel")) {
            PlayerPrefs.SetInt("PlayerLevel", 1);
        }
        if (!PlayerPrefs.HasKey("CurEXP")) {
            PlayerPrefs.SetInt("CurEXP", 0);
        }
        if (!PlayerPrefs.HasKey("PrevGame")) {
            PlayerPrefs.SetInt("PrevGame", 0);
        }
        if (!PlayerPrefs.HasKey("PrevGameCount")) {
            PlayerPrefs.SetInt("PrevGameCount", 0);
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

}
