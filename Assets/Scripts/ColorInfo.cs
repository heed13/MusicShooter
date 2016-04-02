using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public enum TrackColor {
	red,
	blue,
	green,
	yellow,
	purple,
	pink,
	orange,
	fushia,
	brown,
	darkGreen,
	black,
	white
}

public static class TrackColorHandler
{
	const string enemyMatsPath = "Materials/Droids/";
	const string enemyMatString = "defaultMat";
	static List<Color> enumToColor = new List<Color>() {Color.red, Color.blue, Color.green, Color.yellow, 
		new Color(0.5f,0,0.5f), // purple
		Color.magenta, // pink
		new Color(1,0.64f,0), // orange
		new Color(1,0,0.5f), // fushia
		new Color(0.54f,0.27f,0.07f), // brown
		new Color(0,0.39f,0), // dark green
		Color.black, Color.white,
	};

	public static ColorInfo getInfoByColor(TrackColor color)
	{
		ColorInfo c = new ColorInfo();
		c.name = color.ToString ();
		c.color = enumToColor [(int)color];

		// Get enemy material
		string enemyMatFile = enemyMatsPath + enemyMatString + color.ToString ().ToUpper();
		c.enemyMat = (Material)Resources.Load (enemyMatFile);

		// Get enemy map marker
		string enemyMarkerFile = enemyMatsPath + color.ToString ();
		c.mapMarker = Resources.Load<Sprite> (enemyMarkerFile);

		return c;
	}
}
