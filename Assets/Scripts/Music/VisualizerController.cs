using UnityEngine;
using System.Collections.Generic;

public class VisualizerController : MonoBehaviour 
{
	public static VisualizerController instance;
	public GameObject barPrefab;
	public List<VisualizerBar> bars = new List<VisualizerBar>();
	public int freeBar = 0;

	// Use this for initialization
	void Awake ()
	{
		if (VisualizerController.instance == null) {
			VisualizerController.instance = this;
		}
	}

	void centerTracks()
	{

	}
	public void clearTracks()
	{
		for (int i = 0; i < bars.Count; i++) {
			bars [i].SetColor (Color.black);
			bars [i].audioTrack = null;
		}
		freeBar = 0;
	}

	public void addTrack(Track track)
	{
//		GameObject go = (GameObject) Instantiate (barPrefab, transform.position, Quaternion.identity);
	//	go.transform.parent = transform;
	//	bars.Add(go.GetComponent<VisualizerBar>());
		if (freeBar < bars.Count) {
			bars [freeBar].SetColor (track.color.color);
			bars [freeBar++].audioTrack = track;
		}
	}
}
