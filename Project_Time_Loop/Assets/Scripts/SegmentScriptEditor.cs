using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SegmentScript))]
public class SegmentScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SegmentScript myTarget = (SegmentScript)target;
        
        DrawDefaultInspector();

        if (GUILayout.Button("Randomize"))
        {
            myTarget.RandomizeValues();
        }
    }
}
