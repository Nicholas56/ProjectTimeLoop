﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    
    public void  NewGame()
    {
        SceneManager.LoadScene("Buffer");
        //SceneManager.LoadScene("MakeData");
    }

    public void LoadGame(int fileNum)
    {//If there isn't a save file, this does nothing.
        if (GameManager.SaveFileCheck(fileNum))
        {
            GameManager.isLoad = true;
            GameData.saveFileNum = fileNum;
            NewGame();
        }
        else
        {
            return;
        }
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public static void LoadMain()
    {
        SceneManager.LoadScene("BreakFloor",LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
