﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private GameObject[] sprites;
    private GameObject current;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<GameObject>("CharacterSelect/Characters/GameObjects");

        CreateSprite();
    }

    void CreateSprite()
    {
        // TODO: Check this out
        current = Instantiate(sprites[index]) as GameObject;
        current.transform.position = new Vector2(5, 0);
    }

    public void MoveLeft()
    {
        if (index != 0)
        {
            index--;
            Destroy(current);

            CreateSprite();
        }
    }

    public void MoveRight()
    {
        if (index != sprites.Length - 1)
        {
            index++;
            Destroy(current);

            CreateSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
