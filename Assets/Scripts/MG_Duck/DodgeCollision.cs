using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCollision : MonoBehaviour
{
    AudioSource dodgeSound;
    public GameObject scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        dodgeSound  = GameObject.Find("/Audio/DodgeSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collision Detected");
        if (collision.gameObject.name == "Player") {
            /* GameObject go = GameObject.Find ("GameControllerDuck");
            dodgeSound.Play();
            int score = go.GetComponent<DuckGameController>().score;
            score --;
            go.GetComponent<DuckGameController>().score = score;
            Destroy(gameObject); */
            //Debug.Log("Play dodge");
            dodgeSound.Play();
            Destroy(gameObject); 
            GameObject go = GameObject.Find ("GameControllerDuck");
            int score = go.GetComponent<DuckGameController>().score;
            score--;
            go.GetComponent<DuckGameController>().score = score;
        } else if (collision.gameObject.name == "Wall") {
            GameObject go = GameObject.Find("GameController");
            int score = go.GetComponent<DuckGameController>().score;
            score++;
            go.GetComponent<DuckGameController>().score = score;
            Destroy(gameObject);
        }
    }
}
