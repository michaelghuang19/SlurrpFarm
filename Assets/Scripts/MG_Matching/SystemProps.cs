using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
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
    // adjustable time
    private float time = 46;
    private int GameID = 1;
    private bool haveSetExp = false;

    public AudioSource cheer;

    void Start()
    {
        shapes = Resources.LoadAll<GameObject>("Sprites/MinigameElements/Shapes");
        cheer = GameObject.Find("CheerSound").GetComponent<AudioSource>();

        cheer.Stop();
    }



    void Update()
    {
        //MusicSource.Play();
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
            if (!haveSetExp) {
                haveSetExp = true;
                SetExp();
            }
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
            SetExp();
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
        style.normal.textColor = Color.white;
        style.fontSize = 100;
        style.font = (Font)Resources.Load("Thaleah_PixelFont/Materials/ThaleahFat_TTF", typeof(Font));

        int timeinseconds = (int) time;
        GUI.Box(new Rect(10, 10, width / 3, 100), "Time Left : " + timeinseconds.ToString(), style);
        GUI.Box(new Rect(width / 3, 10, width / 3, 100), "Ingredients Left: " + shapesLeft.ToString(), style);
        if (gameover)
        {

            GetComponent<DragAndDrop>().matching = false;

            // fix this, return to screen
            if (gameWon)
            {
                cheer.Play();
                GUI.Label(new Rect(10, height / 2, width / 4, 100), "All ingredients complete in " + (46 - timeinseconds) + " seconds!", style);
            } else
            {
                GUI.Label(new Rect(10, height / 2, width / 4, 100), "You had " + shapesLeft + " ingredients left! Better luck next time", style);
            }
            
            ExitGame();
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Invoke("LoadMenu", 5);
    }

    void SetExp() {
        CheckDefaultPrefs();
        
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        int CurExp = PlayerPrefs.GetInt("CurEXP");
        int PrevGameCount = PlayerPrefs.GetInt("PrevGameCount");
        int PrevGame = PlayerPrefs.GetInt("PrevGame");
        Debug.Log("Level: " + PlayerLevel);
        Debug.Log("CurExp: " + CurExp);



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
        //Debug.Log(PrevGameCount + "");
        exp = (int) (exp * (Math.Pow(0.8, PrevGameCount - 1)));
        //Debug.Log("Exp: " + exp);
        CurExp += exp;
        if (PlayerLevel == 1) {
            if (CurExp >= 100) {
                PlayerLevel += 1;
                CurExp -= 100;
                levelChanged = true;
            }
        } else if (PlayerLevel == 2) {
            if (CurExp >= 200) {
                PlayerLevel += 1;
                CurExp -= 200;
                levelChanged = true;
            }
        } else {
            if (CurExp >= 300) {
                PlayerLevel += 1;
                CurExp -= 300;
                levelChanged = true;
            }
        }

        //Debug.Log("CurExp: " + CurExp);
        PlayerPrefs.SetInt("CurEXP", CurExp);
        PlayerPrefs.SetInt("PrevGameCount", PrevGameCount);
        if (levelChanged) { 
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);
            PlayerPrefs.SetInt("LevelChanged", 1);
        } else {
            PlayerPrefs.SetInt("LevelChanged", 0);
        }
        if (gameChanged) {
            PlayerPrefs.SetInt("PrevGame", GameID);
        }
    }

    void CheckDefaultPrefs() {
        // if (!PlayerPrefs.HasKey("LevelChanged")) {
        //    PlayerPrefs.SetInt("LevelChanged", 0);
        // }
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

}
