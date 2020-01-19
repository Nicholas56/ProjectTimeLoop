using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    Settings settings;
    GameObject[] features;
    GameObject[] portals;

    [SerializeField] static int score;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<GameData>().settings;
        features = GameObject.FindGameObjectsWithTag("Feature");
        switch (settings.mode)
        {
            case Settings.gameMode.Portal:
                portals = GameObject.FindGameObjectsWithTag("Portal");
                SetUpPortalGame();
                break;
        }
        score = 0;
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
            features[p].GetComponent<FeatureScript>().SetID(p % portals.Length + 1);
        }
    }

    public static void AddToScore()
    {
        score++;
    }
}
