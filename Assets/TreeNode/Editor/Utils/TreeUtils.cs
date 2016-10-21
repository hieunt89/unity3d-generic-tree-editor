using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class TreeUtils {

	public static void CreateTree (TreeType _treeType, string _treeName) {

	}

	public static void SaveTree <T> (GenericTree<T> _currentTree) {
		
	}

	public static  void LoadTree () {
		
	}

	public static void UnloadTree () {

	}

	public static string UppercaseFirst(string s)
	{
		// Check for empty string.
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		// Return char and concat substring.
		return char.ToUpper(s[0]) + s.Substring(1);
	}
}
