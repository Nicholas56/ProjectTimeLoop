using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool staticPlaced;

    GameData data;
    public GameObject segmentPrefab;
    public GameObject playerPrefab;
    public GameObject featurePrefab;
    public GameObject wallPrefab;

    public static bool isLoad;

    //The timer will be used to tell the rest of the game what time it is
    public static float gameTimer = 0f;
    public TMP_Text timerTxt;

    //The time before the scene reloads
    [Range(10f, 300f)]
    public static float resetTime = 90f;


    void Start()
    {
        //Calls the reset time function after the given time
        Invoke("ResetTime", resetTime);
        if (!staticPlaced)
        {
            data = FindObjectOfType<GameData>();
            Debug.Log("GameManager started");

            gameObject.AddComponent<RoomMaker>();
            CallRoomMaker();
        }
    }

    void CallRoomMaker()
    {
        Debug.Log("call room maker");
        GetComponent<RoomMaker>().MakeRoom(segmentPrefab,playerPrefab,data.segments, data.settings,wallPrefab);
    }

    private void Update()
    {
        //The game timer will increase with time
        gameTimer += Time.deltaTime;
        timerTxt.text = gameTimer.ToString("n2");
    }

    public void ResetTime()
    {        
        gameTimer = 0;
        FallDeath death = FindObjectOfType<FallDeath>();
        death.fell = true;
        //The scene will be reloaded to reset
        Invoke("ReloadScene", 0.5f);
    }

    void ReloadScene() { SceneManager.LoadScene(0); }


    public static bool SaveFileCheck(int fileNum)
    {
        if (fileNum >= 0)
        {
            if (File.Exists(Application.persistentDataPath + "/playerSave.save" + fileNum))
            {
                return true;
            }
            else { return false; }
        }
        else
        {
            if (File.Exists(Application.persistentDataPath + "/playerSave.save"))
            {
                return true;
            }
            else { return false; }
        }
    }

    public void SaveGame()
    {
        SaveData save = data.saveData;
        string JSONString = JsonUtility.ToJson(save);
        //Quicksave file
        File.WriteAllText(Application.persistentDataPath + "/playerSave.save", JSONString);
        Debug.Log("Something happened");
        Debug.Log(save.savedSegments);
    }

    public void SaveGame(int saveFileNumber)
    {
        SaveData save = data.saveData;
        string JSONString = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/playerSave.save" + saveFileNumber, JSONString);
        Debug.Log("Something happened");
        Debug.Log(save.savedSegments);
    }

    public void ReturnToMenu()
    {
        SaveGame();
        Destroy(FindObjectOfType<GameData>().gameObject);
        Time.timeScale = 1f;
        SceneLoadScript.LoadMenu();
    }
}
