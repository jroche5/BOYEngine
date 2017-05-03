using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StitchNode : NodeBaseClass {

    public int stitchID;

    public StitchNode(Rect r, int ID) : base(r,ID)
    {
        stitchID = id;
        rect = r;
    }

    public override void DrawGUI(int winID)
    {
        BaseDraw();
    }

    public override void AttachComplete(NodeBaseClass winID)
    {
        base.linkedNodes.Add(winID);
    }
}
