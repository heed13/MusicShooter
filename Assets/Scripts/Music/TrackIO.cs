using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;


public class SongIO : MonoBehaviour
{
	const string Path = "Tracks/";
	const string Extension = ".json";


	public void SaveNewSong(ref SongInfo song, bool isNew = true)
	{
		string filename = Path + song.title.Trim ().ToLower ();
		if (File.Exists (filename)) {
			if (isNew) {
				filename += "_new";
			} 
		}

		filename += Extension;
		StreamWriter file = System.IO.File.CreateText (filename);
		//JSONClass.
		file.WriteLine ();

		song.filename = filename;
	}

	public SongInfo ReadFile(string filename)
	{
		//JSON.Parse (new string (File.ReadAllBytes (filename)));
		return new SongInfo();
	}

	private void jsonifySong(SongInfo song)
	{
		JSONObject j = new JSONObject (JSONObject.Type.OBJECT);
		j.AddField ("title", song.title);
		j.AddField ("author", song.author);
		j.AddField ("url", song.url);
		j.AddField ("license", song.license.ToString());
		j.AddField ("notes", song.notes);
		JSONObject trackArr = new JSONObject (JSONObject.Type.ARRAY);
		j.AddField ("tracks", trackArr);
		for (int i = 0; i < song.tracks.Count; i++) {
			JSONObject trackInfoObj = new JSONObject (JSONObject.Type.OBJECT);
			trackInfoObj.AddField ("name", song.tracks [i].name);
//			trackInfoObj.AddField("
			j.Add (trackInfoObj);
		}
	}
}

			//[System.Serializable]
			//public struct SongInfo
			//{
			//	//	private const string[] songLicenseStrings = { "Artistic License 2.0" };
			//
			//	public string title;
			//	public string author;
			//	public string url;
			//	public songLicense license;
			//	public string notes;
			//	public List<TrackInfo> tracks;
			//	public string filename;
			//}

//				[System.Serializable]
//				public struct TrackInfo 
//				{
//					public string name;
//					public AudioClip audioClip;
//					public float currentVolume;
//
//					public ColorInfo color;
//
//					private float muteTime;
//				}