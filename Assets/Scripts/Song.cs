using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum songLicense {
	ArtisticLicense2
}

[System.Serializable]
public struct SongInfo
{
//	private const string[] songLicenseStrings = { "Artistic License 2.0" };
		
	public string title;
	public string author;
	public string url;
	public string license;
	public string notes;
	public List<TrackInfo> tracks;
	public string filename;
}
