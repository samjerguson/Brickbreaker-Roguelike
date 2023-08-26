using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Static vars for whole project
    public static int ballNum;
    public static int defaultBricks;
    public static int plus2Bricks;
    public static int times2Bricks;

    private bool afterFirstBall;

    private void Start()
    {
        GameObject[] defaultBrickObjects = GameObject.FindGameObjectsWithTag("Brick");
        GameObject[] plus2BrickObjects = GameObject.FindGameObjectsWithTag("+2PowerUp");
        GameObject[] times2BrickObjects = GameObject.FindGameObjectsWithTag("x2PowerUp");

        defaultBricks = defaultBrickObjects.Length;
        plus2Bricks = plus2BrickObjects.Length;
        times2Bricks = times2BrickObjects.Length;
    }
    private void Update() //Game over if there are no balls left (does this GO at start of game before ball loads? Maybe only enable it after at least one ball has been created)
    {
        if(ballNum > 0)
            afterFirstBall = true;
        if(ballNum == 0 && afterFirstBall)
        {
            SceneManager.LoadScene("GameOver");
        }
        //print(ballNum);
    }
}
