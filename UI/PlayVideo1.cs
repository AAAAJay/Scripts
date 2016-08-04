using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayVideo1 : MonoBehaviour 
{

	public MovieTexture movie;

	// Use this for initialization
	void Start () 
	{
		GetComponent<RawImage>().texture = movie as MovieTexture;
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		movie.loop = true;
	}
}
