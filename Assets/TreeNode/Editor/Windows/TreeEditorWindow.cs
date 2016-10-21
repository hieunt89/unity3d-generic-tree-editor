using UnityEngine;
using UnityEditor;
using System;


public class TreeEditorWindow : EditorWindow {

	public static TreeEditorWindow currentWindow;

	public TreeWorkView workView;

	private Vector2 scrollPosition;
	private Rect virtualRect;
	private float viewPercentage = 1f;

	object currentGenericTree;

	public static void InitEditorWindow () {
		currentWindow = (TreeEditorWindow) EditorWindow.GetWindow <TreeEditorWindow> ("Tree Editor", true);
		currentWindow.minSize = new Vector2 (600f, 400f);

		currentWindow.workView = new TreeWorkView ();
	}

	void OnGUI () {
		if (workView == null) return;

		Event e = Event.current;
		ProcessEvent (e);

		scrollPosition =  GUI.BeginScrollView(new Rect(0f, 0f, position.width, position.height), scrollPosition, virtualRect); // <-- need to customize this viewrect (expandable by nodes + offset)
		BeginWindows ();
		workView.UpdateView (virtualRect, new Rect (0f, 0f, viewPercentage, 1f), e, currentGenericTree);
		EndWindows ();
		GUI.EndScrollView ();
	}

	void ProcessEvent (Event e) {

	}
}
