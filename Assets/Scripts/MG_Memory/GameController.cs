using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] allCards;

    public List<Sprite> gameCards = new List<Sprite>();

    public List<Button> btns = new List<Button>();
    
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessCard, secondGuessCard;

    private bool gameWon = false;
    private int GameID = 2;


    
    //Awake() gets called before Start()
    void Awake() {
        allCards = Resources.LoadAll<Sprite> ("Sprites/Cards");
    }

    void Start() {
        GetButtons();
        AddListeners();
        AddGameCards();
        gameGuesses = gameCards.Count / 2;
    }

    void GetButtons() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MemoryButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGameCards() {
        int count = btns.Count;
        int index = 0;

        for (int i = 0; i < count; i ++) {
            if (index == count/2) {
                index = 0;
            }

            gameCards.Add(allCards[index]);

            index++;
        }

        Shuffle(gameCards);
        
    }


    //Adds a onClick listener to each card's button programatically
    void AddListeners() {
        foreach(Button btn in btns) {
            btn.onClick.AddListener(() => PickACard());
        }
    }

    void PickACard() {
        Debug.Log ("You are clicking a button");
        //Finding the button that is currently being clicked. 
        
        Debug.Log("First Guess: " + firstGuess + ", Second Guess: " + secondGuess);

        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess) {
            firstGuess = true;
            Debug.Log("First Guess, Name: " + name);
            firstGuessIndex = int.Parse(name);
            firstGuessCard = gameCards[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];

            //Debug.Log("First guess changed sprite to: " + firstGuessIndex);
            
        } else if (!secondGuess) {
            secondGuess = true;
            Debug.Log("Second Guess, Name: " + name);
            secondGuessIndex = int.Parse(name);
            btns[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];
            secondGuessCard = gameCards[secondGuessIndex].name;
            //Debug.Log("Second guess changed sprite to: " + secondGuessIndex);
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch() {
        yield return new WaitForSeconds (1f);

        if (firstGuessCard == secondGuessCard) {

            yield return new WaitForSeconds (.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            CheckIfTheGameIsFinished();

        } else {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            
        }
        firstGuess = false;
        secondGuess = false;
    }

    void CheckIfTheGameIsFinished() {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses) {
            SetExp();
            SceneManager.LoadScene(1);
            Debug.Log("You have finished the game!");
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

    void Shuffle(List<Sprite> list) {
        for (int i = 0; i < list.Count; i++) {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
