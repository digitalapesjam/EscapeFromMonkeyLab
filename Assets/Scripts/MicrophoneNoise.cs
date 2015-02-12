using UnityEngine;
using System.Collections;

public class MicrophoneNoise : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float volume = AudioInput.Volume;
		
		Transform t = GetComponent<Transform>();
		if (t == null) return;
		
		if (volume <= 0) return;
		volume = Mathf.Log(volume);
		
		float s = volume/5;
		t.localScale = new Vector3(s,s,s);
	}
}
