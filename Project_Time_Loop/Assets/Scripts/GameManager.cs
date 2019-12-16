using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //The timer will be used to tell the rest of the game what time it is
    public static float gameTimer = 0f;

    //The time before the scene reloads
    public static float resetTime = 90f;

    void Start()
    {
        //Calls the reset time function after the given time
        Invoke("ResetTime", resetTime);

        //GetComponent<RoomMaker>().MakeRoom();
    }

    private void Update()
    {
        //The game timer will increase with time
        gameTimer += Time.deltaTime;
    }

    void ResetTime()
    {
        gameTimer = 0;
        //The scene will be reloaded to reset
        SceneManager.LoadScene(0);
    }
}
