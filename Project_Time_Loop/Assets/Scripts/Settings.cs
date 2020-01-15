﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoopData;

[CreateAssetMenu()]
public class Settings : ScriptableObject
{
    public enum gameMode { LightGame, CollectionGame, Portal };
    public gameMode mode;

    [Range(3, 19)]
    public int roomSize;

    [Range(0, 50)]
    public int numOfFeatures;
        
    [Range(-10, 0)]
    public float minHeight;

    [Range(0, 10)]
    public float maxHeight;

    [Range(0, 60)]
    public int beginMovingTime = 0;

    public int[] specialFeatures;
    public int featureCall;

    public GameObject lightFeaturePrefab;
    public GameObject portalFeaturePrefab;
    public GameObject carryFeaturePrefab;
    public GameObject collectFeaturePrefab;
    public GameObject unlockFeaturePrefab;
       

    public GameObject wallPrefab;

    public SaveData MakeSave()
    {
        SaveData newSave = CreateData.CreateSaveData(roomSize, beginMovingTime, minHeight, maxHeight, numOfFeatures, mode, specialFeatures);

        return newSave;
    }
}
