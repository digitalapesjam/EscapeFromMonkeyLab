using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)renderer.material.mainTexture).Play();
		audio.Play();
	}
	
	void Update() {
		MovieTexture mt = ((MovieTexture)renderer.material.mainTexture);
		if(!mt.isPlaying || Input.GetKeyUp(KeyCode.Escape)) {
			Application.LoadLevel("Instruction");
		}
	}
}
