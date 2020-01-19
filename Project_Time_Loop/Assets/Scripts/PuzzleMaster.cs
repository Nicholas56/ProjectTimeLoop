using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleMaster : MonoBehaviour
{
    Settings settings;
    GameObject[] features;
    GameObject[] portals;

    TMP_Text messageTxt;

    UnlockFeatureScript[] unlockBox;

    [SerializeField] static int score;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<GameData>().settings;
        features = GameObject.FindGameObjectsWithTag("Feature");
        messageTxt = GameObject.FindGameObjectWithTag("Message").GetComponent<TMP_Text>();
        switch (settings.mode)
        {
            case Settings.gameMode.Portal:
                portals = GameObject.FindGameObjectsWithTag("Portal");
                SetUpPortalGame();
                break;
            case Settings.gameMode.CollectionGame:

                break;
            case Settings.gameMode.LightGame:
                unlockBox = FindObjectsOfType<UnlockFeatureScript>();
                break;
        }
        score = 0;
        MessageTextUpdate();
    }

    public void SetUpPortalGame()
    {
        int[] arr = new int[portals.Length];
        for(int k = 0; k < portals.Length; k++)
        {
            arr[k] = portals[k].GetComponent<FeatureScript>().GetSegmentID();
        }
        int temp;
        GameObject tempPortal;

        //Bubble sorts the ids of the portals
        for (int j = 0; j <= arr.Length - 2; j++)
        {
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                    //Swaps the portals according to id number
                    tempPortal = portals[i + 1];
                    portals[i + 1] = portals[i];
                    portals[i] = tempPortal;
                }
            }
        }

        for(int n = 0;n<portals.Length;n++)
        {
            portals[n].GetComponent<FeatureScript>().SetID(n);
        }
        for(int p = 0; p < features.Length; p++)
        {
            features[p].GetComponent<FeatureScript>().SetID(p % portals.Length);
        }
    }

    public void MessageTextUpdate()
    {
        switch (settings.mode)
        {
            case Settings.gameMode.Portal:
                messageTxt.text = "Click on the boxes to pick them up, click again to drop.\n Carry the boxes to the correct Portal.\n Boxes placed in portals: " + score + "/" + (settings.numOfFeatures-settings.specialFeatures[2]);
                break;
            case Settings.gameMode.CollectionGame:
                messageTxt.text = "Move over the tokens to collects them.\n Collect them all to complete the stage.\n Tokens collected: " + score + "/" + (settings.numOfFeatures - settings.specialFeatures[1]);
                break;
            case Settings.gameMode.LightGame:
                messageTxt.text = "Click on the lights to turn them on.\n Once they're all on, find and click on the hidden box to win.\n Lights turned on: " + score + "/" + (settings.numOfFeatures - settings.specialFeatures[0]);
                break;
        }
    }

    public static void AddToScore()
    {
        score++;
        FindObjectOfType<PuzzleMaster>().MessageTextUpdate();
    }
}
