using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour {
    private GameObject[] sprites;
    private GameObject current;
    private int index = 0;

    public Text name;
    public Text age;

    // Start is called before the first frame update
    void Start () {
        //sprites = Resources.LoadAll<GameObject>("CharacterSelect/Characters/GameObjects");

        //CreateSprite();
    }

    void CreateSprite () {
        // TODO: Check this out
        current = Instantiate (sprites[2]) as GameObject;
        current.transform.position = new Vector2 (0, 0);
    }

    public void SaveData () {
        bool savedName = SaveName ();
        bool savedAge = SaveAge ();

        //Debug.Log ("savedName is " + savedName.ToString ());
        //Debug.Log ("savedAge is " + savedAge.ToString ());

        if (savedName && savedAge) {
            //Debug.Log ("Loading open world");
            SceneManager.LoadScene (1);
        }
    }

    public bool SaveName () {

        if (name.text == "") {
            // gameObject.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Please enter your name!";

            name.text = "Please enter your name!";
            return false;
        } else {
            //Debug.Log (name.text);
            string nameString = name.text;
            PlayerPrefs.SetString ("Name", nameString);
            //Debug.Log ("Saved name is " + PlayerPrefs.GetString ("Name"));
            return true;
        }
    }

    public bool SaveAge () {
        if (age.text == "") {
            // name.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Please enter your age!";

            age.text = "Please enter your age!";
            return false;
        } else {
            //Debug.Log (age.text);
            int ageInteger = int.Parse (age.text);
            PlayerPrefs.SetInt ("Age", ageInteger);
            //Debug.Log ("Saved age is " + PlayerPrefs.GetInt ("Age"));
            return true;
        }
    }

    public void MoveLeft () {
        if (index != 0) {
            index--;
            Destroy (current);

            CreateSprite ();
        }
    }

    public void MoveRight () {
        if (index != sprites.Length - 1) {
            index++;
            Destroy (current);

            CreateSprite ();
        }
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(name.text);
    }
}