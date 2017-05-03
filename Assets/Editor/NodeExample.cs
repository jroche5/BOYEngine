using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeExample : EditorWindow {

    public List<Stitch> myStitches = new List<Stitch>();
    public List<NodeBaseClass> myNodes = new List<NodeBaseClass>();
    public Spool targetSpool;

    public bool editorToggle = false;
    public int nodeSelected = 0;

    public int nodeAttachID = -1;
    [MenuItem("Node Editor/ Editor")]
	public static void showWindow()
    {
        GetWindow<NodeExample>();
    }

    public void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        targetSpool = (Spool)EditorGUILayout.ObjectField(targetSpool, typeof(Spool), false);
        if (EditorGUI.EndChangeCheck())
        {
            myNodes.Clear();
            if (targetSpool != null)
            {
                for (int i = 0; i < targetSpool.stitchCollection.Length; i++)
                {
                    myNodes.Add(new StitchNode(new Rect(100 * i, 20, 100, 100), i));
                }
            }
        }

        if (targetSpool != null)
        {

            for (int i = 0; i < targetSpool.stitchCollection.Length; i++)
            {
                for (int j = 0; j < targetSpool.stitchCollection[i].yarns.Length; j++)
                {
                    if(targetSpool.stitchCollection[i].yarns[j].choiceStitch != null)
                        DrawNodeCurve(myNodes[i].rect, myNodes[targetSpool.stitchCollection[i].yarns[j].choiceStitch.stitchID].rect);
                }
            }
        }

        BeginWindows();
        for(int i = 0; i < myNodes.Count; i++)
        {
            myNodes[i].rect = GUI.Window(i, myNodes[i].rect, myNodes[i].DrawGUI, targetSpool.stitchCollection[i].stitchName);
        }
        EndWindows();

       for (int i = 0; i < myNodes.Count; i++)
        {
            if(GUI.Button(new Rect(myNodes[i].rect.x + myNodes[i].rect.height - 70, myNodes[i].rect.yMax, 40, 20), "Edit"))
            {
                //Open Edit Window
                editorToggle = true;
                nodeSelected = i;
            }
			/*if (GUI.Button(new Rect(myNodes[i].rect.xMax - 10, myNodes[i].rect.y + myNodes[i].rect.height / 2, 20, 20), "+"))
            {
                BeginAttachment(i);
            }

            if (GUI.Button(new Rect(myNodes[i].rect.xMin - 10, myNodes[i].rect.y + myNodes[i].rect.height / 2, 20, 20), "O"))
            {
                EndAttachment(i);
            }*/
        }

       if(editorToggle)
        {
            Rect editorWindow = new Rect(position.width - position.width / 3, 0, position.width / 3, position.height);
            EditorGUI.DrawRect(editorWindow, Color.black);
        }
    }

    public void RemoveNode(int id)
    {
        for (int i = 0; i < myNodes.Count; i++)
        {
            myNodes[i].linkedNodes.RemoveAll(item => item.id == id);
        }
        myNodes.RemoveAt(id);
        UpdateNodeIDs();
    }

    public void UpdateNodeIDs()
    {
        for(int i = 0; i < myNodes.Count; i++)
        {
            myNodes[i].ReassignID(i);
        }
    }

    public void BeginAttachment(int winID)
    {
        nodeAttachID = winID;
    }
        
    public void EndAttachment(int winID)
    {
        if (nodeAttachID > -1)
        {
            myNodes[nodeAttachID].AttachComplete(myNodes[winID]);
        }
        nodeAttachID = -1;
    }

    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + (start.height / 2)+10, 0);
        Vector3 endPos = new Vector3(end.x, end.y + (end.height / 2)+ 10, 0);
        Vector3 startTan = startPos + Vector3.right * 100;
        Vector3 endTan = endPos + Vector3.left * 100;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

       
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 5);
    }

}
