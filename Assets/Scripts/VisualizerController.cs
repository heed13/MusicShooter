using UnityEngine;
using System.Collections.Generic;

public class VisualizerController : MonoBehaviour 
{
	public static VisualizerController instance;
	public List<VisualizerBar> bars;
	public int freeBar = 0;

	// Use this for initialization
	void Awake ()
	{
		if (VisualizerController.instance == null) {
			VisualizerController.instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void linkTrack(Track track)
	{
		if (freeBar < bars.Count) {
			bars [freeBar].SetColor (track.color.color);
			bars [freeBar++].audioTrack = track.audioSource;
		}
	}
}
