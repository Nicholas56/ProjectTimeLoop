using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LoopData;
//Nicholas Easterby - EAS12337350
//This script controls the data being used and tells the scene how to act
public class GameData : MonoBehaviour
{
    public List<Segment> segments; 

    public Settings settings;

    public static int saveFileNum = -1;

    public SaveData saveData = new SaveData();
    
    void Awake()
    {
        //This destroys copies of GameData upon resetting the scene
        if (FindObjectsOfType<GameData>().Length > 1) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);

        //If sava data is being loaded, finds the information and loads it ready to be used
        if (GameManager.SaveFileCheck(saveFileNum)&&GameManager.isLoad)
        {
            //Empties previous data
            segments = null;

            //Checks if save file or quick save data
            if (saveFileNum >= 0)
            {
                string JSONSTring = File.ReadAllText(Application.persistentDataPath + "/playerSave.save" + saveFileNum);
                saveData = JsonUtility.FromJson<SaveData>(JSONSTring);
            }
            else
            {
                string JSONSTring = File.ReadAllText(Application.persistentDataPath + "/playerSave.save");
                saveData = JsonUtility.FromJson<SaveData>(JSONSTring);
                Debug.Log(JSONSTring);
            }

            GameManager.isLoad = false;
            Debug.Log("This stuff loaded");
        }
        else
        {
            //If no save data, creates new randomized data for map
            List<string> serializedSegments = new List<string>();

            saveData = settings.MakeSave();
             
            Debug.Log("New data is being created!");
            string JSONString = JsonUtility.ToJson(saveData);
            GameManager.isLoad = true;//Quicksave file
            File.WriteAllText(Application.persistentDataPath + "/playerSave.save", JSONString);
        }

        // Using the data currently available, deserializes each string and loads the segment data
        List<Segment> unserializedSegments = new List<Segment>();
        for (int i = 0; i < saveData.sizeOfRoom * saveData.sizeOfRoom; i++)
        {
            Segment newSegment = JsonUtility.FromJson<Segment>(saveData.savedSegments[i]);
            unserializedSegments.Add(newSegment);
        }
        segments = unserializedSegments;

        SceneLoadScript.LoadMain();
    }
}

public struct SaveData
{
    //Custom save data format
    public List<string> savedSegments;
    public List<Vector3> savedSegmentPositions;
    public List<float> savedYPositions;
    public List<int> savedMovementTimes;
    public List<Feature.element> savedFeaturePlacements;

    public int sizeOfRoom;
}
