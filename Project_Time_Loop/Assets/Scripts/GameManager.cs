using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    GameData data;
    public GameObject segmentPrefab;
    public GameObject playerPrefab;
    public GameObject featurePrefab;
    public static bool isLoad;

    //The timer will be used to tell the rest of the game what time it is
    public static float gameTimer = 0f;

    //The time before the scene reloads
    [Range(10f, 300f)]
    public static float resetTime = 90f;

    void Start()
    {
        //Calls the reset time function after the given time
        Invoke("ResetTime", resetTime);
        data = FindObjectOfType<GameData>();
        Debug.Log("GameManager started");
        gameObject.AddComponent<RoomMaker>();
        CallRoomMaker();
    }

    void CallRoomMaker()
    {
        Debug.Log("call room maker");
        GetComponent<RoomMaker>().MakeRoom(segmentPrefab,playerPrefab,data.segments, featurePrefab, data.mode);
    }

    private void Update()
    {
        //The game timer will increase with time
        gameTimer += Time.deltaTime;
    }

    public void ResetTime()
    {
        gameTimer = 0;
        //The scene will be reloaded to reset
        SceneManager.LoadScene(0);
    }

    public static bool SaveFileCheck()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSave.save"))
        {
            return true;
        }
        else { return false; }
    }

     public void SaveGame()
    {
        SaveData save = data.saveData;
        string JSONString = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/playerSave.save", JSONString);
        Debug.Log("Something happened");
        Debug.Log(save.savedSegments);
    }

    public void ReturnToMenu()
    {
        Destroy(FindObjectOfType<GameData>().gameObject);
        SceneLoadScript.LoadMenu();
    }
}
