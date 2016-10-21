using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class DataManager {
	#region Singleton
	private static DataManager instance = null;
	public static DataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new DataManager();
			}
			return instance;
		}
	}
	#endregion

	#region json data
	const string dataDirectory = "Assets/Resources/Data/";

	public void SaveData<T> (T data) {

		var jsonString = JsonUtility.ToJson(data);
		Debug.Log(jsonString);

		FieldInfo field = typeof(T).GetField("id");
		string id = (string) field.GetValue(data);
		if (!Directory.Exists (dataDirectory + data.ToString ())) {
			Directory.CreateDirectory (dataDirectory + data.ToString ());
		}
		File.WriteAllText (dataDirectory + data.ToString () + "/"  + id + ".json", jsonString);

		AssetDatabase.Refresh();
	}

	public T LoadData<T> () {
		var path = EditorUtility.OpenFilePanel("Load " +  typeof(T).ToString(), dataDirectory +  typeof(T).ToString(), "json");

		var reader = new WWW("file:///" + path);
		while(!reader.isDone){
		}

		return (T) JsonUtility.FromJson (reader.text, typeof(T));
	}

	public List<T> LoadAllData <T> () {
		var list = new List<T> ();
		var path = "Data/" + typeof(T).ToString();
		TextAsset[] files = Resources.LoadAll <TextAsset> (path) as TextAsset[];
		if (files != null && files.Length > 0) {
			for (int i = 0; i < files.Length; i++) {
				T datum = (T)JsonUtility.FromJson (files [i].text, typeof(T));
				list.Add (datum);
			}
		}
		return list;
	}

	public T LoadDataById <T> (string id) {
		var path = "Data/" + typeof(T).ToString() + "/" + id;
		TextAsset file = Resources.Load <TextAsset> (path) as TextAsset;
		return (T)JsonUtility.FromJson (file.text, typeof(T));
	
	}

	#endregion json data

}
