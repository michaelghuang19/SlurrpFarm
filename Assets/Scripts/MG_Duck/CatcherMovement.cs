using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherMovement : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 20f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            direction = (touchPos - transform.position);
            rb.velocity = new Vector2(0, direction.y) * moveSpeed;

            if(touch.phase == TouchPhase.Ended) {
                rb.velocity = Vector2.zero;
            }

        }
    }

}
