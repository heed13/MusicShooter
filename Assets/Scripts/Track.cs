using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct TrackInfo 
{
	public string name;
	public List<AudioClip> audioClips;
	public string notes;
	public ColorInfo color;
}

public class Track : MonoBehaviour 
{
	public new string name;
	public string path;
	public List<AudioSource> audioSources = new List<AudioSource>();
	public float maxVolume;
	public ColorInfo color;

	public float onEmptyEventTimer = 1;
	public MultiTrackGame.TrackEmptyEvent onEmptyEvent;

	[HideInInspector]
	public float currentVolume = 1;

	private float decayRate = .03f;
	private float incrementAmount = .6f;
	private float muteTime;
	private float nextOnEmptyEvent = 0;

	void Update()
	{
		Decay ();
		currentVolume = audioSources [0].volume;
	}

	void Decay()
	{
		for (int i = 0; i < audioSources.Count; i++) {
			if (audioSources[i].volume > 0 && !GameManager.instance.godMode) {
				audioSources[i].volume -= Time.deltaTime * decayRate;
			} else if (audioSources[i].volume <= 0 && Time.time >= nextOnEmptyEvent) {
				nextOnEmptyEvent = Time.time + onEmptyEventTimer;
				onEmptyEvent.Invoke ();
			}
		}
	}

	public void IncementTimer(float amount = -1)
	{
		amount = (amount != -1) ? amount : incrementAmount;
		for (int i = 0; i < audioSources.Count; i++) {
			audioSources[i].volume += amount;
		}
	}

	public void load(TrackInfo info, float _maxVolume)
	{
		for (int i = 0; i < info.audioClips.Count; i++) {
			AudioSource source = gameObject.AddComponent<AudioSource> ();
			audioSources.Add(source);
			source.clip = info.audioClips[i];
			source.loop = true;
			source.playOnAwake = true;
			source.volume = maxVolume = _maxVolume;
			source.Play ();
		}
		color = info.color;
		VisualizerController.instance.addTrack (this);
	}
}
