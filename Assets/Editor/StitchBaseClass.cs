using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StitchBaseClass : Editor {

    public int stitchID;
    public Rect rect;
    public string title;
    public string summary;
    public Sprite background;

    public List<Performer> performers = new List<Performer>();

    public List<Dialog> dialog = new List<Dialog>();

    public List<Yarn> yarn = new List<Yarn>();

    public enum stitchStatus { start, end, regular, auto };
    public stitchStatus status;

    public StitchBaseClass(Rect r, int id)
    {
        stitchID = id;
        rect = r;
    }

    public void BaseDraw()
    {
        EditorGUILayout.LabelField("Stitch ID: " + stitchID);
        title = EditorGUILayout.TextField(title);
        summary = EditorGUILayout.TextArea(summary);
        background = (Sprite)EditorGUILayout.ObjectField(background, typeof(Sprite), false);
    }

    public virtual void DrawGUI(int winID)
    {
        GUILayout.Label("You forgot to override");
    }
}
