using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public List<Segment> segments;

    public enum gameMode { LightGame, CollectionGame};
    public gameMode mode;

    [Range(3,19)]
    public int roomSize = 4;

    [Range(0, 50)]
    public int numOfFeatures = 10;

    //The min and Max heights need to be set here!!
    //[Range(-10,)]
    
    List<Vector3> segmentPositions;
    List<float> timedYPos;
    List<int> timesForMovement = new List<int>();

    List<Segment.featureType> holdingFeature;

    public SaveData saveData;
    
    void Awake()
    {
        //This destroys copies of GameData upon resetting the scene
        if (FindObjectsOfType<GameData>().Length > 1) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);

        if (GameManager.SaveFileCheck()&&GameManager.isLoad)
        {
            saveData = new SaveData();
            segments = null;
            segmentPositions = null;
            timedYPos = null;
            timesForMovement = null;


            string JSONSTring = File.ReadAllText(Application.persistentDataPath + "/playerSave.save");
            saveData = JsonUtility.FromJson<SaveData>(JSONSTring);
            Debug.Log(JSONSTring);

            // GO through EACH STRING ANd DESERIALize iT.
            List<Segment> unserializedSegments = new List<Segment>();
            for(int i = 0; i < saveData.sizeOfRoom * saveData.sizeOfRoom; i++)
            {
                Segment newSegment = JsonUtility.FromJson<Segment>(saveData.savedSegments[i]);
                unserializedSegments.Add(newSegment);
            }
            segments = unserializedSegments;
            segmentPositions = saveData.savedSegmentPositions;
            timedYPos = saveData.savedYPositions;
            timesForMovement = saveData.savedMovementTimes;
            holdingFeature = saveData.savedFeaturePlacements;

            GameManager.isLoad = false;
            Debug.Log("This stuff happened");
            Debug.Log(segments[0].posAtTime);

        }
        else
        {
            CreateMap();
            CreateTimedPositionHeight();
            CreateFeature();

            segments = new List<Segment>();
            List<string> serializedSegments = new List<string>();

            for (int i = 0; i < roomSize * roomSize; i++)
            {
                int randValue = Random.Range(0, Mathf.FloorToInt(GameManager.resetTime));
                timesForMovement.Add(randValue);

                Segment newSegment = new Segment(segmentPositions[i], i, randValue, timedYPos, holdingFeature[i]);
                segments.Add(newSegment);
                serializedSegments.Add(JsonUtility.ToJson(newSegment));
            }
            
            SaveData currentSave = new SaveData();
            currentSave.savedSegments = serializedSegments;
            currentSave.savedSegmentPositions = segmentPositions;
            currentSave.savedYPositions = timedYPos;
            currentSave.savedMovementTimes = timesForMovement;
            currentSave.sizeOfRoom = roomSize;
            currentSave.savedFeaturePlacements = holdingFeature;
            saveData = currentSave;
            Debug.Log("New data is being created!");
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

    void CreateFeature()
    {
        holdingFeature = new List<Segment.featureType>();
        for(int j = 0; j < roomSize * roomSize; j++) { holdingFeature.Add(Segment.featureType.None); }
        for(int i= 0; i < roomSize * roomSize; i++)
        {
            int randNum = Random.Range(i, roomSize * roomSize);
            switch (mode)
            {
                case gameMode.LightGame:
                    if (numOfFeatures == 1) { holdingFeature[randNum] = Segment.featureType.Unlockable;break; }
                    holdingFeature[randNum] = Segment.featureType.Light;

                    break;
                case gameMode.CollectionGame:
                    holdingFeature[randNum] = Segment.featureType.Collectable;

                    break;
            }
            numOfFeatures--;
            if (numOfFeatures == 0) { return; }
        }
        if (numOfFeatures > 0) { print("Not every feature has been assigned"); }
    }
    
}

public struct SaveData
{
    public List<string> savedSegments;
    public List<Vector3> savedSegmentPositions;
    public List<float> savedYPositions;
    public List<int> savedMovementTimes;
    public List<Segment.featureType> savedFeaturePlacements;

    public int sizeOfRoom;
}
