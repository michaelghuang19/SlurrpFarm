using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    private bool gameWon = false;
    private int GameID = 4;
    private bool timeOn = false;
    private float totalTime = 45;
    private float time = 45;
    
    public Text timeText;
    public GameObject timeMessage;
    public GameObject winMessage;
    public GameObject loseMessage;
    public GameObject joystick;
    public GameObject instructionCanvas;
    // Start is called before the first frame update
    void Start()
    {
        winMessage.SetActive(false);
        loseMessage.SetActive(false);
        timeText.gameObject.SetActive(false);
        timeMessage.SetActive(false);
        joystick.gameObject.SetActive(false);
    }

    public void StartTime() {
        timeOn = true;
        timeText.gameObject.SetActive(true);
        timeMessage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0) {
            timeOn = false;
        } 
        if (timeOn && !gameWon) {
            time -= Time.deltaTime;
            //Debug.Log(time);
            timeText.text = "" + time;
        } else {
            if (time < totalTime) {
                if (!gameWon) {
                    loseMessage.SetActive(true);
                    //Debug.Log("Lose Message Active");
                } 
                gameWon = false;
                Invoke("endGame", 1);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Detected");
        if (collision.gameObject.name == "Monkey")
        {
            //Debug.Log("Collision detected");
            winMessage.SetActive(true);
            gameWon = true;
            Invoke("endGame", 1);
        }
    }
    public void DisableInstructionMaze()
    {
        instructionCanvas.gameObject.SetActive(false);
        joystick.gameObject.SetActive(true);
    }

    void endGame() {
        SetExp();
        SceneManager.LoadScene(1);
    }
    void SetExp()
    {
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        int CurExp = PlayerPrefs.GetInt("CurEXP");
        int PrevGameCount = PlayerPrefs.GetInt("PrevGameCount");
        int PrevGame = PlayerPrefs.GetInt("PrevGame");
        //Debug.Log("Level: " + PlayerLevel);
        //Debug.Log("CurExp: " + CurExp);

        bool levelChanged = false;
        bool gameChanged = false;

        int exp = 0;

        if (gameWon)
        {
            exp += 100;
        }
        else
        {
            exp += 34;
        }

        if (PrevGame != GameID)
        {
            PrevGameCount = 0;
            gameChanged = true;
        }
        else
        {
            PrevGameCount += 1;
        }
        //Debug.Log(PrevGameCount + "");
        exp = (int)(exp * (Math.Pow(0.8, PrevGameCount - 1)));
        //Debug.Log("Exp: " + exp);
        CurExp += exp;
        if (PlayerLevel == 1)
        {
            if (CurExp >= 100)
            {
                PlayerLevel += 1;
                CurExp -= 100;
                levelChanged = true;
            }
        }
        else if (PlayerLevel == 2)
        {
            if (CurExp >= 200)
            {
                PlayerLevel += 1;
                CurExp -= 200;
                levelChanged = true;
            }
        }
        else
        {
            if (CurExp >= 300)
            {
                PlayerLevel += 1;
                CurExp -= 300;
                levelChanged = true;
            }
        }

        //Debug.Log("CurExp: " + CurExp);
        PlayerPrefs.SetInt("CurEXP", CurExp);
        PlayerPrefs.SetInt("PrevGameCount", PrevGameCount);
        if (levelChanged)
        {
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);
            PlayerPrefs.SetInt("LevelChanged", 1);
        }
        else
        {
            PlayerPrefs.SetInt("LevelChanged", 0);
        }
        if (gameChanged)
        {
            PlayerPrefs.SetInt("PrevGame", GameID);
        }
    }
  
}
