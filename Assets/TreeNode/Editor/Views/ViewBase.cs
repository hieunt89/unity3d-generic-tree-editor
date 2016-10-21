using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

public class ViewBase {

	public string viewTitle;
	public Rect viewRect;

	protected GUISkin viewSkin;
	protected object currentGenericTree;
	protected Type type;

	public ViewBase () {
		GetEditorSkin ();
	}

	public virtual void UpdateView <T> (Rect _editorRect, Rect _percentageRect, Event _e, GenericTree<T> _currentGenericTree) {
		if (viewSkin == null) {
			GetEditorSkin ();
			return;
		}

		type = typeof(GenericTree <>).MakeGenericType(typeof(T));
		currentGenericTree = Activator.CreateInstance(type);
		this.currentGenericTree = _currentGenericTree;

		viewRect = new Rect (
			_editorRect.x * _percentageRect.x,
			_editorRect.y * _percentageRect.y,
			_editorRect.width * _percentageRect.width,
			_editorRect.height * _percentageRect.height
		);
	}

	public virtual void ProcessEvent <T> (Event e) {
	}

	protected void GetEditorSkin () {
		viewSkin = (GUISkin)Resources.Load ("EditorSkins/TreeNodeEditorSkin");
	}
}
