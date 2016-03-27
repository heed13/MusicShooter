using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TrackInfo 
{
	public string name;
	public AudioClip audioClip;
	public float currentVolume;

	public ColorInfo color;

	private float muteTime;
}

public class Track : MonoBehaviour 
{
	public new string name;
	public string path;
	public AudioSource audioSource;
	public float maxVolume;
	public ColorInfo color;

	public float onEmptyEventTimer = 1;
	public MultiTrackGame.TrackEmptyEvent onEmptyEvent;

	private float decayRate = .03f;
	private float incrementAmount = .6f;
	private float muteTime;
	private float nextOnEmptyEvent = 0;

	void Update()
	{
		Decay ();
	}

	void Decay()
	{
		if (audioSource.volume > 0 && !GameManager.instance.godMode) {
			audioSource.volume -= Time.deltaTime * decayRate;
		} else if (audioSource.volume <= 0 && Time.time >= nextOnEmptyEvent) {
			nextOnEmptyEvent = Time.time + onEmptyEventTimer;
			onEmptyEvent.Invoke ();
		}
	}

	public void IncementTimer()
	{
		audioSource.volume += incrementAmount;
	}

	public void load(TrackInfo info, float _maxVolume)
	{
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = info.audioClip;
		audioSource.loop = true;
		audioSource.playOnAwake = true;
		audioSource.volume = maxVolume = _maxVolume;
		audioSource.Play ();
		color = info.color;
		VisualizerController.instance.linkTrack (this);
	}
}
