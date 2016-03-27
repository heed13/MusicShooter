using UnityEngine;
using System.Collections;

[System.Serializable]
public struct ColorInfo 
{
	public string name;
	public Color color;
	public Material enemyMat;
	public Sprite mapMarker;

	public ColorInfo(string _name, Color _color, Material _enemyMat, Sprite _mapMarker)
	{
		name = _name;
		color = _color;
		enemyMat = _enemyMat;
		mapMarker = _mapMarker;
	}
}
