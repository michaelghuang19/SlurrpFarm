﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float lockPos = 0;
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;
        Vector2 newPosition = transform.position;
        newPosition.x = newPosition.x + 50f * horizontalMove * Time.deltaTime;
        newPosition.y = newPosition.y + 50f * verticalMove * Time.deltaTime;
        if(newPosition.x < 980.5 && newPosition.x > 400 && newPosition.y > 120 && newPosition.y < 398.6)
        {
            animator.SetFloat("MoveX", horizontalMove);
            animator.SetFloat("MoveY", verticalMove);
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        }
    }


}
