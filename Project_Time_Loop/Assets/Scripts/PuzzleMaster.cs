using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    Settings settings;
    GameObject[] features;
    int checkNum;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<GameData>().settings;
        features = GameObject.FindGameObjectsWithTag("Feature");
    }

    // Update is called once per frame
    void Update()
    {
        switch (settings.mode)
        {
            case Settings.gameMode.LightGame:
                checkNum = 0;
                foreach(GameObject feature in features)
                {
                    if (feature.GetComponent<FeatureScript>().Check())
                    {
                        checkNum++;
                    }
                }
                if (checkNum == settings.numOfFeatures - settings.specialFeatures[0])
                {

                }
                break;
            case Settings.gameMode.CollectionGame:

                break;
            case Settings.gameMode.Portal:

                break;
        }
    }
}
