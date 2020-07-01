using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    // screen positions
    // static so we can access this even with no reference to this class
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        // converts screen's pixel coord to game's coord
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        // instantiate the two paddle separately
        Paddle paddleRight = Instantiate(paddle) as Paddle;
        Paddle paddleLeft = Instantiate(paddle) as Paddle;

        paddleRight.Init("right");
        paddleLeft.Init("left");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
