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

        public static List<Segment.featureType> CreateFeature(int numOfFeatures, int roomSizeSqrd, Settings.gameMode mode)
        {
            List<Segment.featureType> holdingFeature = new List<Segment.featureType>();
            for (int j = 0; j < roomSizeSqrd; j++) { holdingFeature.Add(Segment.featureType.None); }
            for (int i = 0; i < roomSizeSqrd; i++)
            {
                int randNum = Random.Range(i, roomSizeSqrd);
                switch (mode)
                {
                    case Settings.gameMode.LightGame:
                        if (numOfFeatures == 1) { holdingFeature[randNum] = Segment.featureType.Unlockable; break; }
                        holdingFeature[randNum] = Segment.featureType.Light;

                        break;
                    case Settings.gameMode.CollectionGame:
                        holdingFeature[randNum] = Segment.featureType.Collectable;

                        break;
                    case Settings.gameMode.Portal:
                        if (numOfFeatures > 0 && numOfFeatures < 3)
                        {
                            holdingFeature[randNum] = Segment.featureType.Portal;
                        }
                        else
                        {
                            holdingFeature[randNum] = Segment.featureType.Carry;
                        }
                        break;
                }
                numOfFeatures--;
                if (numOfFeatures == 0) { return holdingFeature; }
            }

            return holdingFeature;
        }

        public static SaveData CreateSaveData(int roomSize, int beginMovingTime, float minHeight, float maxHeight, int numOfFeatures, Settings.gameMode mode)
        {
            List<Vector3> segmentPositions = CreateMap(roomSize);
            List<float> timedYPos = CreateTimedPositionHeight(minHeight, maxHeight);
            List<Segment.featureType> holdingFeature = CreateFeature(numOfFeatures, roomSize * roomSize, mode);

            List<Segment> segments = new List<Segment>();
            List<int> timesForMovement = new List<int>();
            List<string> serializedSegments = new List<string>();

            for (int i = 0; i < roomSize*roomSize; i++)
            {
                int randValue = Random.Range(beginMovingTime, Mathf.FloorToInt(GameManager.resetTime));
                timesForMovement.Add(randValue);
                //Makes new Segments here!
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
