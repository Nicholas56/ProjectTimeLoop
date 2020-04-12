using UnityEngine;
using System.Collections;
using UnityEditor;
//Nicholas Easterby - EAS12337350
//Provides button on segments for manipulation in editor
[CustomEditor(typeof(SegmentScript))]
public class SegmentScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SegmentScript myTarget = (SegmentScript)target;
        
        DrawDefaultInspector();

        //Makes a button that calls a specific function
        if (GUILayout.Button("Randomize"))
        {
            myTarget.RandomizeValues();
        }
    }
}
