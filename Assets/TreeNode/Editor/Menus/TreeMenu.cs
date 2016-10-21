using UnityEngine;
using UnityEditor;

public static class TreeMenu {

	[MenuItem ("Tree Editor/Open")]
	public static void InitEditorWindow () {
		TreeEditorWindow.InitEditorWindow ();
	}
}
