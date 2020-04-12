using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Nicholas Easterby - EAS12337350
//This script handles scene transitions
public class SceneLoadScript : MonoBehaviour
{
    
    public void  NewGame()
    {
        //Move to the buffer scene
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
        //This adds the main game scene to the buffer scene, allowing access to gameobjects in both scenes
        SceneManager.LoadScene("BreakFloor",LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
