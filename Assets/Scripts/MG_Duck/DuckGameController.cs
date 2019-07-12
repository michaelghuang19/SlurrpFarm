using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DuckGameController : MonoBehaviour
{
    
    //public Sprite item;

    public GameObject character;
    public Text scoreText;

    private GameObject[] items;

    private int gameReps;

    public int score = 0;
    private int itemsLeft = 10;
    private bool gameOver = false;
    private float speed = -5f;
    private int GameID = 3;

    private Queue curObjs = new Queue();

    void Awake()
    {
        //Load items into possibleItems
        items = Resources.LoadAll<GameObject> ("Dodge");
    }

    void Start() 
    {
        //Start createObjects(), which loops, and runs for x amount of times (based on difficulty later)
        Debug.Log("CreateObjects called");
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
    }


    private void CreateObjects() {
        if (itemsLeft == 0) {
            gameOver = true;
            endGame();
        } else {
            /* if (curObjs.Count > 0) {
                GameObject item = curObjs.Dequeue() as GameObject;
                Destroy(item);
            } */
            Debug.Log("Creating object: " + itemsLeft);
            Invoke("CreateObjects", 3);
            int index = UnityEngine.Random.Range(0, items.Length);
            GameObject randomShape = Instantiate(items[index]) as GameObject;
            int height = UnityEngine.Random.Range(-3, 3);
            randomShape.transform.position = new Vector2(7, height);
            randomShape.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            //curObjs.Enqueue(randomShape);
            itemsLeft--;
        }

    }

    private void endGame() {
        SetExp();
        SceneManager.LoadScene(1);
    }

    void SetExp() {
        CheckDefaultPrefs();
        
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        int CurExp = PlayerPrefs.GetInt("CurEXP");
        int PrevGameCount = PlayerPrefs.GetInt("PrevGameCount");
        int PrevGame = PlayerPrefs.GetInt("PrevGame");
        //Debug.Log("Level: " + PlayerLevel);
        //Debug.Log("CurExp: " + CurExp);



        bool levelChanged = false;
        bool gameChanged = false;

        int exp = 0;

        if (score > 2) {
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
        if (!PlayerPrefs.HasKey("LevelChanged")) {
            PlayerPrefs.SetInt("LevelChanged", 0);
        }
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
