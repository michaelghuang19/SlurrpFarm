﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCollision : MonoBehaviour
{   
    AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GameObject.Find("/Audio/CatchSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collision Detected");
        if (collision.gameObject.name == "Player") {
            //Debug.Log("Play hit");
            hitSound.Play();
            Destroy(gameObject); 
            GameObject go = GameObject.Find ("GameControllerDuck");
            go.GetComponent<DuckGameController>();
            int score = go.GetComponent<DuckGameController>().score;
            score++;
            go.GetComponent<DuckGameController>().score = score;
        } else if (collision.gameObject.name == "Wall") {
            Destroy(gameObject);
        }
    }
}
