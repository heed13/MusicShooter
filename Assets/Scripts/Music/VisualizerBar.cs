using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VisualizerBar : MonoBehaviour {
	public Track audioTrack;
	private Slider slider;

	void Start()
	{
		slider = GetComponent<Slider> ();
	}
	
	void LateUpdate ()
	{
		if (audioTrack != null)
			slider.value = audioTrack.currentVolume * 100;
	}

	public void SetColor(Color col)
	{
		Transform child = transform.Find ("Fill Area/Fill");
		if (child != null)
			child.GetComponent<Image> ().color = col;
	}
}
