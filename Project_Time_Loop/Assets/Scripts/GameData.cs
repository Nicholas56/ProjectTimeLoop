using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public List<Segment> segments;

    [Range(3,19)]
    public int roomSize = 4;
    
    List<Vector3> segmentPositions;
    public static List<float> timedYPos;
    List<int> timesForMovement = new List<int>();

    public SaveData saveData;
    
    void Awake()
    {
        //This destroys copies of GameData upon resetting the scene
        if (FindObjectsOfType<GameData>().Length > 1) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);

        if (GameManager.SaveFileCheck()&&GameManager.isLoad)
        {
            string JSONSTring = File.ReadAllText(Application.persistentDataPath + "/playerSave.save");
            saveData = JsonUtility.FromJson<SaveData>(JSONSTring);
            Debug.Log(JSONSTring);

            // GO through EACH STRING ANd DESERIALize iT.
            List<string> unserializedSegments = new List<string>();
            for(int i)
            segments = JsonUtility.FromJson<List<Segment>>(saveData.savedSegments);
            segmentPositions = saveData.savedSegmentPositions;
            timedYPos = saveData.savedYPositions;
            timesForMovement = saveData.savedMovementTimes;

            GameManager.isLoad = false;
            Debug.Log("This stuff happened");
            Debug.Log(segments);

        }
        else
        {
            CreateMap();
            CreateTimedPositionHeight();

            segments = new List<Segment>();
            List<string> serializedSegments = new List<string>();

            for (int i = 0; i < roomSize * roomSize; i++)
            {
                int randValue = Random.Range(0, Mathf.FloorToInt(GameManager.resetTime));
                timesForMovement.Add(randValue);

                Segment newSegment = new Segment(segmentPositions[i], i, randValue);
                segments.Add(newSegment);
                serializedSegments[i] = JsonUtility.ToJson(newSegment);
            }
            
            SaveData currentSave = new SaveData();
            currentSave.savedSegments = serializedSegments;
            currentSave.savedSegmentPositions = segmentPositions;
            currentSave.savedYPositions = timedYPos;
            currentSave.savedMovementTimes = timesForMovement;
            saveData = currentSave;
            Debug.Log(currentSave.savedSegments);
        }

        SceneLoadScript.LoadMain();
    }  

    void CreateTimedPositionHeight()
    {
        timedYPos = new List<float>();
        for(int i = 0; i<GameManager.resetTime; i++)
        {
            float randHeight = Random.Range(-9f, 10f);
            timedYPos.Add(randHeight);
        }
    }

    void CreateMap()
    {
        segmentPositions = new List<Vector3>();

        for(int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {
                Vector3 pos = new Vector3(x * 5, 0, y * 5);
                segmentPositions.Add(pos);
            }
        }
    }
    
}

public struct SaveData
{
    public List<string> savedSegments;
    public List<Vector3> savedSegmentPositions;
    public List<float> savedYPositions;
    public List<int> savedMovementTimes;    
}
