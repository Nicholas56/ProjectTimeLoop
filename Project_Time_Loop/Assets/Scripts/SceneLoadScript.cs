using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    public void NewGame()
    {
        LoadMain();
    }

    public void LoadGame()
    {

    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadMain()
    {
        SceneManager.LoadScene("BreakFloor");
    }
}
