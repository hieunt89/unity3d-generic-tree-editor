using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public interface IGenericTree {
	
}

public class GenericTree <T> : IGenericTree {
	
}

public class GenericTreeUI {
	public void UpdateTreeUI (Event _e, Rect _viewRect, GUISkin _viewSkin) {
		
	}
}