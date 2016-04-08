using UnityEngine;

public class AudioVisualizer : MonoBehaviour {
	public int detail = 500;
	public float minValue = 1.0f;
	public float amplitude = 0.1f;

	private float randomAmplitude = 1.0f;
	private Vector3 startScale;
	private Vector3 startPos;

	void Start()
	{
		startScale = transform.localScale;
		startPos = transform.position;

		randomAmplitude = Random.Range (0.5f, 1.5f);
	}

	void FixedUpdate()
	{
		float[] info = new float[detail];
		AudioListener.GetOutputData(info, 0); 
		float packagedData = 0.0f;

		for(int x = 0; x < info.Length; x++)
		{
			packagedData += System.Math.Abs(info[x]);   
		}

		transform.localScale = new Vector3(minValue, (packagedData * amplitude * randomAmplitude) + startScale.y, minValue);
		transform.position = new Vector3 (transform.position.x, startPos.y+transform.localScale.y / 2, transform.position.z);
	}
}