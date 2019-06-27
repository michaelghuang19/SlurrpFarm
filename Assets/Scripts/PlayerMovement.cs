using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    // Update is called once per frame
    void Update()
    {

        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;
        Vector2 position = transform.position;
        position.x = position.x + 30f * horizontalMove * Time.deltaTime;
        position.y = position.y + 30f * verticalMove * Time.deltaTime;
        transform.position = position;
    }


}
