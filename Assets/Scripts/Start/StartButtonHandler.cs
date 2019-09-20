using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    public void StartGame () {
        // PlayerPrefs test
        // PlayerPrefs.SetString ("Name", "Patrick");
        // PlayerPrefs.SetInt ("Age", 10);

        // Reset PlayerPrefs
        // PlayerPrefs.DeleteAll();

        //Debug.Log (PlayerPrefs.GetString ("Name"));
        //Debug.Log (PlayerPrefs.GetInt ("Age"));

        //Debug.Log ("Start Button Clicked");

        if (PlayerPrefs.HasKey ("Name") && PlayerPrefs.HasKey ("Age")) {
            SceneManager.LoadScene (1);
        } else {
            SceneManager.LoadScene (5);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}