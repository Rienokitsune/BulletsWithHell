using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Sirenix.OdinInspector;

//Editor part of PathCreation tool
//Handles saving and editing of the bezier curves
//TODO,creation of other types of paths

[CustomEditor(typeof(PathCreator))]
public class PathEditorWindow : Editor
{
    PathCreator creator;
    RawPathData instance;
    [ShowInInspector]List<Vector2> waypoints;
    string PathID;

    void OnEnable()
    {
        Debug.Log("path editor enabled");
        creator = (PathCreator)target;

        if (creator.pathData == null || creator.pathData.NumOfPoints == 0)
        {
            creator.createPath();
            
        }
        instance = creator.pathData;
        waypoints = new List<Vector2>();

        Debug.Log(instance.NumOfPoints);
    }

    public override void OnInspectorGUI()
    {
        
        base.OnInspectorGUI();
        
        GUILayout.Label("PathID");
        PathID = EditorGUILayout.TextField(PathID);
        if (GUILayout.Button("createNew"))
        {
            creator.createPath();
            instance = creator.pathData;
            Debug.Log("created path");
            SceneView.RepaintAll();
        }
        if (GUILayout.Button("1. Generate waypoints"))
        {
           waypoints = getPointsInSegments();
        }
        if (GUILayout.Button("2. SaveToFile"))
        {
            SavePath();
        }


    }
    
    void OnSceneGUI()
    {
        //Debug.Log("drawingSceneGui");
        Input();
        Draw();
    }


    void SavePath()
    {

        PathData pathAsset = new PathData(waypoints);
        PathAsset SO = CreateInstance<PathAsset>();
        SO.SetPath(pathAsset);
        SO.name = creator.bundle.name + "_" + PathID;
        

        AssetDatabase.CreateAsset(SO, "Assets/"+SO.name+".asset");
        creator.createPath();
        instance = creator.pathData;
        waypoints = new List<Vector2>();
        Debug.Log("AssetSaved");
    }



    void Input()
    {
        Debug.Log("handlinginput");
        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;
        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            Undo.RecordObject(creator, "create segment");
            instance.AddSegment(mousePos);
        }
    }


    void Draw()
    {
        if(waypoints.Count != 0)
        {

        for (int i = 0; i < waypoints.Count; i++)
        {
            Handles.FreeMoveHandle(waypoints[i], Quaternion.identity, 0.2f, Vector2.zero, Handles.CylinderHandleCap);
        }

        }
        

        Debug.Log("isDrawing");
        for (int i = 0; i < instance.NumOfSegments; i++)
        {
            Vector2[] points =instance.GetPointsInSegment(i);
            Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.green, null, 2);
            Handles.DrawLine(points[0], points[1]);
            Handles.DrawLine(points[2], points[3]);
        }

        Handles.color = Color.blue;

        for (int i = 0; i < instance.NumOfPoints; i++)
        {

            
            //Debug.Log("isDrawing");


            Vector2 newPos = Handles.FreeMoveHandle(instance[i], Quaternion.identity, 0.2f, Vector2.zero, Handles.CylinderHandleCap);
            Handles.color = Color.red;
            // Debug.Log(path[i]);
            if (instance[i] != newPos)
            {
                Undo.RecordObject(creator, "Move Point");
                instance.MovePoint(i, newPos);
            }
        }
    }

    List<Vector2> getPointsInSegments()
    {
        List<Vector2> points = new List<Vector2>();
        for (int i = 0; i < instance.NumOfSegments; i++)
        {
            GetSegmentPoints(i,points);
        }
        return points;
    }

    void GetSegmentPoints( int segment, List<Vector2> list)
    {
       
        int sections = 10;
        float tStart = 0;
        float tEnd = 1;
        //Divide the curve into sections
        float delta = (tEnd - tStart) / (float)sections;

        //The start position of the curve
        Vector3 lastPos = DeCasteljausAlgorithm(tStart,segment);
        list.Add(lastPos);
        

        //Move along the curve
        for (int i = 1; i <= sections; i++)
        {
            //Calculate the t value at this section
            float t = tStart + delta * i;

            //Find the coordinates at this t
            Vector3 pos = DeCasteljausAlgorithm(t,segment);
            list.Add(pos);

            lastPos = pos;
        }

        
    }

    //The De Casteljau's Algorithm
    Vector3 DeCasteljausAlgorithm(float t, int segment)
    {

        Vector3 A = instance.GetPointsInSegment(segment)[0];
        Vector3 B = instance.GetPointsInSegment(segment)[1];
        Vector3 C = instance.GetPointsInSegment(segment)[2];
        Vector3 D = instance.GetPointsInSegment(segment)[3];

        //Linear interpolation = lerp = (1 - t) * A + t * B
        //Could use Vector3.Lerp(A, B, t)

        //To make it faster
        float oneMinusT = 1f - t;

        //Layer 1
        Vector3 Q = oneMinusT * A + t * B;
        Vector3 R = oneMinusT * B + t * C;
        Vector3 S = oneMinusT * C + t * D;

        //Layer 2
        Vector3 P = oneMinusT * Q + t * R;
        Vector3 T = oneMinusT * R + t * S;

        //Final interpolated position
        Vector3 U = oneMinusT * P + t * T;

        return U;
    }
    
}