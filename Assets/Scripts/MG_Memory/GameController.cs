using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] allCards;

    public List<Sprite> gameCards = new List<Sprite> ();
    public List<Button> btns = new List<Button> ();

    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int allowedGuesses = 10;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessCard, secondGuessCard;

    private bool gameWon = false;
    private int GameID = 2;

    private GameObject winMessage;
    private GameObject lossMessage;
    private Text scoreText;
    private ParticleSystem winParticles;

    public AudioSource cardSetup;
    public AudioSource cardFail;
    public AudioSource cardSuccess;
    public AudioSource cheer;

    //Awake() gets called before Start()
    void Awake () {
        allCards = Resources.LoadAll<Sprite> ("Sprites/Cards");
    }

    void Start () {
        GetButtons ();
        AddListeners ();
        AddGameCards ();
        gameGuesses = gameCards.Count / 2;

        winMessage = GameObject.Find ("Win");
        lossMessage = GameObject.Find ("Loss");
        winParticles = GameObject.Find ("WinParticles").GetComponent<ParticleSystem> ();

        winMessage.SetActive (false);
        lossMessage.SetActive (false);

        cardSetup = GameObject.Find ("/Audio/CardSetup").GetComponent<AudioSource> ();
        cardFail = GameObject.Find ("/Audio/CardFail").GetComponent<AudioSource> ();
        cardSuccess = GameObject.Find ("/Audio/CardSuccess").GetComponent<AudioSource> ();
        cheer = GameObject.Find ("/Audio/CheerSound").GetComponent<AudioSource> ();
        scoreText = GameObject.Find ("/Canvas/TurnsLeft").GetComponent<Text> ();

        cardSetup.Stop ();
        cardFail.Stop ();
        cardSuccess.Stop ();
        cheer.Stop ();
    }

    void GetButtons () {
        GameObject[] objects = GameObject.FindGameObjectsWithTag ("MemoryButton");

        for (int i = 0; i < objects.Length; i++) {
            btns.Add (objects[i].GetComponent<Button> ());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGameCards () {
        int count = btns.Count;
        int index = 0;

        for (int i = 0; i < count; i++) {
            if (index == count / 2) {
                index = 0;
            }

            gameCards.Add (allCards[index]);

            index++;
        }

        cardSetup.Play ();
        Shuffle (gameCards);

    }

    //Adds a onClick listener to each card's button programatically
    void AddListeners () {
        foreach (Button btn in btns) {
            btn.onClick.AddListener (() => PickACard ());
        }
    }

    void PickACard () {
        //Debug.Log ("You are clicking a button");
        //Finding the button that is currently being clicked. 

        //Debug.Log("First Guess: " + firstGuess + ", Second Guess: " + secondGuess);

        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess) {
            cardFail.Play ();

            firstGuess = true;
            //Debug.Log("First Guess, Name: " + name);
            firstGuessIndex = int.Parse (name);
            firstGuessCard = gameCards[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];

            //Debug.Log("First guess changed sprite to: " + firstGuessIndex);

        } else if (!secondGuess) {
            cardFail.Play ();
            secondGuessIndex = int.Parse (name);
            if (secondGuessIndex != firstGuessIndex) {
                secondGuess = true;
                //Debug.Log("Second Guess, Name: " + name);
                btns[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];
                secondGuessCard = gameCards[secondGuessIndex].name;
                //Debug.Log("Second guess changed sprite to: " + secondGuessIndex);
                StartCoroutine (CheckIfThePuzzlesMatch ());
            }
        }

    }

    IEnumerator CheckIfThePuzzlesMatch () {
        yield return new WaitForSeconds (1.5f);

        if (firstGuessCard == secondGuessCard) {
            cardSuccess.Play ();

            yield return new WaitForSeconds (.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color (0, 0, 0, 0);

            countCorrectGuesses++;
        } else {
            cardFail.Play ();

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;

        }
        countGuesses++;
        CheckIfTheGameIsFinished ();
        firstGuess = false;
        secondGuess = false;
    }

    void CheckIfTheGameIsFinished () {
        bool isOver = false;
        if (countCorrectGuesses == gameGuesses) {
            cheer.Play ();

            gameWon = true;
            isOver = true;
        } else if (countGuesses >= allowedGuesses) {
            gameWon = false;
            isOver = true;
        }
        if (isOver) {
            gameOverMessage ();
            SetExp ();
            Debug.Log ("You have finished the game!");
            Invoke ("LoadOpenWorld", 5);
        } else {
            int turnsLeft = allowedGuesses - countGuesses;
            scoreText.text = "" + (turnsLeft);

            StartCoroutine(FadeTextToFullAlpha(0.5f, scoreText));
            StartCoroutine(FadeTextToZeroAlpha(1f, scoreText));
        }
    }

    void LoadOpenWorld () {
        SceneManager.LoadScene (1);
    }

    void gameOverMessage () {
        // checking if number of user guesses is maxed out, i.e. game over
        // doesn't yet work since countGuesses hasn't been used yet
        if (gameWon) {
            winMessage.SetActive (true);
            winParticles.Play ();
        } else {
            lossMessage.SetActive (true);
        }
    }

    void SetExp () {
        CheckDefaultPrefs ();

        int PlayerLevel = PlayerPrefs.GetInt ("PlayerLevel");
        int CurExp = PlayerPrefs.GetInt ("CurEXP");
        int PrevGameCount = PlayerPrefs.GetInt ("PrevGameCount");
        int PrevGame = PlayerPrefs.GetInt ("PrevGame");
        Debug.Log ("Level: " + PlayerLevel);
        Debug.Log ("CurExp: " + CurExp);

        bool levelChanged = false;
        bool gameChanged = false;

        int exp = 0;

        if (gameWon) {
            exp += 100;
        } else {
            exp += 34;
        }

        if (PrevGame != GameID) {
            PrevGameCount = 0;
            gameChanged = true;
        } else {
            PrevGameCount += 1;
        }
        exp = (int) (exp * (Math.Pow (0.8, PrevGameCount - 1)));
        Debug.Log ("Exp: " + exp);
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

        Debug.Log ("CurExp: " + CurExp);
        PlayerPrefs.SetInt ("CurEXP", CurExp);
        PlayerPrefs.SetInt ("PrevGameCount", PrevGameCount);
        if (levelChanged) {
            PlayerPrefs.SetInt ("PlayerLevel", PlayerLevel);
            PlayerPrefs.SetInt ("LevelChanged", 1);
        } else {
            PlayerPrefs.SetInt ("LevelChanged", 0);
        }
        if (gameChanged) {
            PlayerPrefs.SetInt ("PrevGame", GameID);
        }
    }

    void CheckDefaultPrefs () {

        if (!PlayerPrefs.HasKey ("PlayerLevel")) {
            PlayerPrefs.SetInt ("PlayerLevel", 1);
        }
        if (!PlayerPrefs.HasKey ("CurExp")) {
            PlayerPrefs.SetInt ("CurExp", 0);
        }
        if (!PlayerPrefs.HasKey ("PrevGame")) {
            PlayerPrefs.SetInt ("PrevGame", 0);
        }
        if (!PlayerPrefs.HasKey ("PrevGameCount")) {
            PlayerPrefs.SetInt ("PrevGameCount", 0);
        }
    }

    void Shuffle (List<Sprite> list) {
        for (int i = 0; i < list.Count; i++) {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range (i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public IEnumerator FadeTextToFullAlpha (float t, Text i) {
        i.color = new Color (i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f) {
            i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha (float t, Text i) {
        i.color = new Color (i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f) {
            i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}