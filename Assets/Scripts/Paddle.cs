using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] // visible on Unity
    float speed;

    float height;

    string input;
    public bool isRight;

    void Start()
    {
        height = transform.localScale.y;
    }

    // needs to be public so GameManager sees it
    public void Init(string direction)
    {
        isRight = direction.Equals("right");

        Vector2 position = Vector2.zero;

        if (direction.Equals("right"))
        {
            position = new Vector2(GameManager.topRight.x, 0);
            // adds offset to include all paddle width (its centered)
            position -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else if (direction.Equals("left"))
        {
            position = new Vector2(GameManager.bottomLeft.x, 0);
            position += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";

        }

        // update paddle position
        transform.position = position;

        // name of paddle object
        transform.name = input;
    }

    void Update()
    {
        // GetAxis is Positive or negative
        // Time.deltaTime makes it framerate independent
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // restrict paddle space
        bool hitTop =
            transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0;
        bool hitBottom =
            transform.position.y > GameManager.topRight.y - height / 2 && move > 0;
        if (hitTop || hitBottom)
        {
            move = 0; // stops paddle
        }

        // Vector2.up is 0 or 1
        transform.Translate(move * Vector2.up);
    }
}
