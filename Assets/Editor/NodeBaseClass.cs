using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeBaseClass : Editor {
    public int id;
    public Rect rect;
    public string title;
    public delegate void voidFunction(int id);
    public voidFunction closeFunction;

    public NodeExample nodeEditor;
    public List<NodeBaseClass> linkedNodes = new List<NodeBaseClass>();

    public NodeBaseClass(Rect r, int ID)
    {
        id = ID;
        rect = r;
    }
    public void BaseDraw()
    {
       
        Color temp = GUI.backgroundColor;
        GUI.backgroundColor = Color.red;

        if(GUI.Button(new Rect(rect.width-18,-1,18,18),"X"))
        {
            closeFunction(id);
        }
        GUI.backgroundColor = temp;
        GUI.DragWindow();
    }

    public virtual void DrawGUI(int winID)
    {
        GUILayout.Label("You forgot to override");
    }

    public void ReassignID(int newID)
    {
        id = newID;
    }

    public virtual void AttachComplete(NodeBaseClass winID)
    {
        linkedNodes.Add(winID);
    }
}
