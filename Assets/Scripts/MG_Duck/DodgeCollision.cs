using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCollision : MonoBehaviour
{
    public GameObject scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision Detected");
        if (collision.gameObject.name == "Player") {
            GameObject go = GameObject.Find ("GameController");
            int score = go.GetComponent<DuckGameController>().score;
            score --;
            go.GetComponent<DuckGameController>().score = score;
            Destroy(gameObject);
        } else if (collision.gameObject.name == "Wall") {
            GameObject go = GameObject.Find("GameController");
            int score = go.GetComponent<DuckGameController>().score;
            score++;
            go.GetComponent<DuckGameController>().score = score;
            Destroy(gameObject);
        }
    }
}
