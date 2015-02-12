using UnityEngine;
using System.Collections;

public class PlaySoundUntilCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//audio.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.name == "PlayerRef"){
			Physics.IgnoreCollision(collider,c.collider);
			AudioSource s = GetComponent<AudioSource>();
			if(!s.isPlaying) 
				s.Play();
		}
	}
	
	void OnTriggerEnter(Collider collInfo) {
		//if (collInfo.name == "PlayerRef"){
		//	AudioSource s = GetComponent<AudioSource>();
		//	if(!s.isPlaying) {
		//		s.Play();
		//	}
		//}
		}
	}
