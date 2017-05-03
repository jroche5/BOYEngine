using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeA : NodeBaseClass {


    public NodeA (Rect r, int ID) : base(r,ID)
    {
        
    }

    public override void DrawGUI(int winID)
    {
        GUILayout.Label(id.ToString());
        GUILayout.Label("Node : A");
        foreach(NodeBaseClass n in linkedNodes)
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
