using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopData
{
    public static class CreateData
    {
        public static List<float> CreateTimedPositionHeight(float minHeight, float maxHeight)
        {
            List<float> timedYPos = new List<float>();
            for (int i = 0; i < GameManager.resetTime; i++)
            {
                float randHeight = Random.Range(minHeight, maxHeight);
                timedYPos.Add(randHeight);
            }

            return timedYPos;
        }

        public static List<Vector3> CreateMap(int roomSize)
        {
            List<Vector3> segmentPositions = new List<Vector3>();

            for (int x = 0; x < roomSize; x++)
            {
                for (int y = 0; y < roomSize; y++)
                {
                    Vector3 pos = new Vector3(x * 5, 0, y * 5);
                    segmentPositions.Add(pos);
                }
            }
            return segmentPositions;
        }

        public static List<Feature.element> CreateFeature(int numOfFeatures, int roomSizeSqrd, Settings.gameMode mode, int[] specialFeatures)
        {
            List<Feature.element> holdingFeature = new List<Feature.element>();
            for (int j = 0; j < roomSizeSqrd; j++) { holdingFeature.Add(Feature.element.None); }
            for (int i = 0; i < roomSizeSqrd; i++)
            {
                int randNum = Random.Range(i, roomSizeSqrd);
                switch (mode)
                {
                    case Settings.gameMode.LightGame:
                        if (numOfFeatures == specialFeatures[0]) { holdingFeature[randNum] = Feature.element.Unlock; break; }
                        holdingFeature[randNum] = Feature.element.Light;

                        break;
                    case Settings.gameMode.CollectionGame:
                        holdingFeature[randNum] = Feature.element.Collect;

                        break;
                    case Settings.gameMode.Portal:
                        if (numOfFeatures > 0 && numOfFeatures < specialFeatures[1])
                        {
                            holdingFeature[randNum] = Feature.element.Basket;
                        }
                        else
                        {
                            holdingFeature[randNum] = Feature.element.Carry;
                        }
                        break;
                }
                numOfFeatures--;
                if (numOfFeatures == 0) { return holdingFeature; }
            }

            return holdingFeature;
        }

        public static SaveData CreateSaveData(int roomSize, int beginMovingTime, float minHeight, float maxHeight, int numOfFeatures, Settings.gameMode mode, int[] featureNums)
        {
            List<Vector3> segmentPositions = CreateMap(roomSize);
            List<float> timedYPos = CreateTimedPositionHeight(minHeight, maxHeight);
            List<Feature.element> holdingFeature = CreateFeature(numOfFeatures, roomSize * roomSize, mode, featureNums);

            List<Segment> segments = new List<Segment>();
            List<int> timesForMovement = new List<int>();
            List<string> serializedSegments = new List<string>();

            for (int i = 0; i < roomSize*roomSize; i++)
            {
                int randValue = Random.Range(beginMovingTime, Mathf.FloorToInt(GameManager.resetTime));
                timesForMovement.Add(randValue);
                //Makes new Segments here!
                Debug.Log(holdingFeature[i]);
                Segment newSegment = new Segment(segmentPositions[i], i, randValue, timedYPos, holdingFeature[i]);
                segments.Add(newSegment);
                serializedSegments.Add(JsonUtility.ToJson(newSegment));
            }

            SaveData currentSave = new SaveData
            {
                savedSegments = serializedSegments,
                savedSegmentPositions = segmentPositions,
                savedYPositions = timedYPos,
                savedMovementTimes = timesForMovement,
                sizeOfRoom = roomSize,
                savedFeaturePlacements = holdingFeature
            };
            return currentSave;
        }
    }
}
