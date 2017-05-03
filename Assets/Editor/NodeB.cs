using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeB : NodeBaseClass {

    public NodeB(Rect r, int ID) : base(r,ID)
    {

    }

    public override void DrawGUI(int winID)
    {
        GUILayout.Label(id.ToString());
        GUILayout.Label("Node : B");
        foreach (NodeBaseClass n in linkedNodes)
        {
            GUILayout.Label("Linked to:  " + n.id);
        }
        BaseDraw();
    }

    public override void AttachComplete(NodeBaseClass winID)
    {
        base.linkedNodes.Add(winID);
    }
}
