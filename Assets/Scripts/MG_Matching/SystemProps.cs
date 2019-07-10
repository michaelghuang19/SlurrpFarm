﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemProps : MonoBehaviour
{
    public Text timeLeft;

    public int score = 0;
    public int shapesLeft = 10;
    private GameObject correctShape;
    private GameObject[] shapes;
    private bool gameover = false;
    private bool gameWon = false;
    private bool timeOn = true;
    // adjustable time
    private float time = 31;
    private int GameID = 1;

    private float virtualWidth = 1920.0f;
    private float virtualHeight = 1080.0f;

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Sprites/MinigameElements/Shapes");

    }

    public void updateTime()
    {
        timeLeft.text = "Time Left: " + time.ToString();
    }

    void Update()
    {
        if (time <= 0)
        {
            timeOn = false;
        }

        if (timeOn)
        {
            time -= Time.deltaTime;
        }
        else
        {
            gameover = true;
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
            randomShape.transform.position = new Vector2(-6, 0);
        }
        else
        {
            gameWon = true;
            timeOn = false;
            gameover = true;
        }
    }

    public void AddScore(GameObject shape)
    {
        correctShape = shape;
        Invoke("AddScoreHelper", 1);
    }

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 100;
        // Font friendlyFont = Resources.Load<Font>("StarkerMarker/Fonts/StarkerMarker.ttf");
        style.font = (Font)Resources.Load("StarkerMarker/Fonts/StarkerMarker", typeof(Font));

        // GUI.Box(new Rect(0, 10, width / 3, 100), "Score: " + score.ToString(), style);
        int timeinseconds = (int) time;
        GUI.Box(new Rect(10, 10, width / 3, 100), "Time Left : " + timeinseconds.ToString(), style);
        GUI.Box(new Rect(width / 3, 10, width / 3, 100), "Shapes Left: " + shapesLeft.ToString(), style);
        if (gameover)
        {

            GetComponent<DragAndDrop>().matching = false;

            // fix this, return to screen
            if (gameWon)
            {
                GUI.Label(new Rect(width / 4, height / 2, width / 4, 100), "All ingredients complete in " + (30 - timeinseconds) + " seconds!", style);
            } else
            {
                GUI.Label(new Rect(width / 4, height / 2, width / 4, 100), "You had " + shapesLeft + " ingredients left! Better luck next time", style);
            }

            ExitGame();
        }
    }

    void ExitGame()
    {
        SetExp();
        Invoke("LoadMenu", 5);
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
