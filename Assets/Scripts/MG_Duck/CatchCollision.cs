using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCollision : MonoBehaviour
{   
    AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision Detected");
        if (collision.gameObject.name == "Player") {
            hitSound.Play();
            Destroy(gameObject); 
            GameObject go = GameObject.Find ("GameController");
            int score = go.GetComponent<DuckGameController>().score;
            score++;
            go.GetComponent<DuckGameController>().score = score;
        } else if (collision.gameObject.name == "Wall") {
            Destroy(gameObject);
        }
    }
}
