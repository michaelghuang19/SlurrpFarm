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
        position.x = position.x + 100f * horizontalMove * Time.deltaTime;
        position.y = position.y + 100f * verticalMove * Time.deltaTime;
        if(position.x < 980.5 && position.x > 400 && position.y > 120 && position.y < 398.6)
        {
            transform.position = position;
        }
    }


}
