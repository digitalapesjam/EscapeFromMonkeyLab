using UnityEngine;
using System.Collections;

[AddComponentMenu("Audio/PlayAudioWhenMoving")]
public class PlayAudioWhenMoving : MonoBehaviour {

	private AudioSource prevSoundType;
	
	// Use this for initialization
	void Start () {
		prevSoundType = GetComponents<AudioSource>()[0];
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController c = GetComponent<CharacterController>();
		AudioSource tilesStep = GetComponents<AudioSource>()[0];
		AudioSource carpetSteps = GetComponents<AudioSource>()[1];
		
		//GameObject[] tilesFloors = GameObject.FindGameObjectsWithTag("Tile Floor");
		GameObject[] carpetFloors = GameObject.FindGameObjectsWithTag("Carpet Floor");
		
		AudioSource s = tilesStep;
		for (int i=0; i<carpetFloors.Length; i++)
			if (carpetFloors[i].renderer.bounds.max.x > transform.position.x && carpetFloors[i].renderer.bounds.min.x < transform.position.x)
				s = carpetSteps;
		
		if(c.velocity.magnitude < 100 || !c.isGrounded || prevSoundType != s) {
			tilesStep.Stop();
			carpetSteps.Stop();
			prevSoundType = s;
		} else if(!s.isPlaying) {
			s.Play();
		}
	}
}
