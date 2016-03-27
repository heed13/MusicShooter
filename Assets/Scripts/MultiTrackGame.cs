using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class MultiTrackGame : MonoBehaviour {
	public static MultiTrackGame instance;
	public float maxVolume = 1;
	public List<TrackInfo> trackInfo;
	public int numTracks;

	private List<Track> tracks = new List<Track>();

	public GameObject trackTarget;

	[System.Serializable]
	public class TrackEmptyEvent : UnityEvent { }
	public TrackEmptyEvent onEmptyEvent;


	void Awake()
	{
		if (MultiTrackGame.instance == null) {
			MultiTrackGame.instance = this;
		}
		for (int i = 0; i < trackInfo.Count; i++) {
			addTrack (trackInfo [i]);
		}
		numTracks = tracks.Count;

	}

	void addTrack(TrackInfo info)
	{
		Track track = trackTarget.AddComponent<Track> ();
		track.load (info, maxVolume);
		track.onEmptyEvent = onEmptyEvent;
		tracks.Add (track);
	}

	public void incrementTimeOfTrack(int trackId)
	{
		tracks [trackId].IncementTimer ();
	}

}
