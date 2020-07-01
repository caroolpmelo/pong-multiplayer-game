using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    void Start()
    {
        // direction is (1, 1)
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // restrict ball space
        bool hitTop =
            transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0;
        bool hitBottom =
            transform.position.y > GameManager.topRight.y - radius && direction.y > 0;
        if (hitTop || hitBottom)
        {
            direction.y *= -1; // invert ball direction
        }

        // also game over
        bool hitLeft =
            transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0;
        bool hitRight =
            transform.position.x > GameManager.topRight.x - radius && direction.x > 0;
        if (hitLeft || hitRight)
        {
            if (hitLeft) Debug.Log("Right player wins!");
            else Debug.Log("Left player wins!");

            Time.timeScale = 0; // TODO: do a win or lost screen and remove this
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if collide with paddle
        if (other.tag.Equals("Paddle"))
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            if (
                (isRight && direction.x > 0) || (!isRight && direction.x < 0)
            )
            {
                direction.x *= -1; // invert ball direction
            }
        }
    }
}
